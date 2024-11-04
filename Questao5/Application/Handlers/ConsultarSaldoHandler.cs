using MediatR;
using Questao5.Application.Queries;
using Questao5.Domain.Entities;
using Questao5.Domain.ValueObjects;
using Questao5.Infrastructure.Database;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Handlers
{
    public class ConsultarSaldoHandler : IRequestHandler<ConsultarSaldoQuery, SaldoResponse>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ConsultarSaldoHandler(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<SaldoResponse> Handle(ConsultarSaldoQuery request, CancellationToken cancellationToken)
        {
            // Validações
            var conta = await _contaCorrenteRepository.ObterContaCorrenteAsync(request.Idcontacorrente);
            if (conta == null) return new SaldoResponse { Sucesso = false, Mensagem = "Conta não encontrada.", Tipo = "INVALID_ACCOUNT" };
            if (!conta.Ativo) return new SaldoResponse { Sucesso = false, Mensagem = "Conta inativa.", Tipo = "INACTIVE_ACCOUNT" };

            var movimentos = await _contaCorrenteRepository.ObterMovimentosAsync(request.Idcontacorrente);

            decimal saldo = movimentos
                .Where(m => m.Tipomovimento == "C")
                .Sum(m => m.Valor) -
                movimentos
                .Where(m => m.Tipomovimento == "D")
                .Sum(m => m.Valor);

            return new SaldoResponse
            {
                Sucesso = true,
                Saldo = saldo,
                ContaCorrente = conta
            };
        }
    }
}
