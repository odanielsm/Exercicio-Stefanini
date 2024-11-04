using MediatR;
using Questao5.Application.Commands;
using Questao5.Domain.Entities;
using Questao5.Domain.ValueObjects;
using Questao5.Infrastructure.Database;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Handlers
{
    public class RegistrarMovimentacaoHandler : IRequestHandler<RegistrarMovimentacaoCommand, MovimentacaoResponse>
    {
        private readonly IContaCorrenteRepository _repository;

        public RegistrarMovimentacaoHandler(IContaCorrenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<MovimentacaoResponse> Handle(RegistrarMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            // Validações
            var conta = await _repository.ObterContaCorrenteAsync(request.Idcontacorrente);
            if (conta == null) return new MovimentacaoResponse { Sucesso = false, Mensagem = "Conta não encontrada.", Tipo = "INVALID_ACCOUNT" };
            if (!conta.Ativo) return new MovimentacaoResponse { Sucesso = false, Mensagem = "Conta inativa.", Tipo = "INACTIVE_ACCOUNT" };
            if (request.Valor <= 0) return new MovimentacaoResponse { Sucesso = false, Mensagem = "Valor inválido.", Tipo = "INVALID_VALUE" };
            if (request.Tipomovimento != "C" && request.Tipomovimento != "D") return new MovimentacaoResponse { Sucesso = false, Mensagem = "Tipo inválido.", Tipo = "INVALID_TYPE" };

            // Verifica idempotência
            if (await _repository.ExisteMovimentoAsync(request.Idempotencia))
                return new MovimentacaoResponse { Sucesso = false, Mensagem = "Requisição já processada.", Tipo = "IDEMPOTENCIA" };

            var movimento = new Movimento
            {
                Idmovimento = Guid.NewGuid().ToString(),
                Idcontacorrente = request.Idcontacorrente,
                Datamovimento = DateTime.Now,
                Tipomovimento = request.Tipomovimento,
                Valor = request.Valor
            };

            await _repository.AdicionarMovimentoAsync(movimento, request.Idempotencia);

            return new MovimentacaoResponse { Sucesso = true, IdMovimento = movimento.Idmovimento };
        }
    }
}
