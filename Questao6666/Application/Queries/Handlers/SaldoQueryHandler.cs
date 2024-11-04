using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Queries.Handlers
{
    public class SaldoQueryHandler : IRequestHandler<SaldoQueryRequest, SaldoQueryResponse>
    {
        public async Task<SaldoQueryResponse> Handle(SaldoQueryRequest request, CancellationToken cancellationToken)
        {
            // Lógica para obter o saldo
            var saldo = new SaldoQueryResponse
            {
                // Popule a resposta com os dados do saldo
            };
            return saldo;
        }
    }
}
