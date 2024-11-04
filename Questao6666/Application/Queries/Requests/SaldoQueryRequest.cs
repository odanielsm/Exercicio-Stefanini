using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class SaldoQueryRequest : IRequest<SaldoQueryResponse>
    {
        public int ContaId { get; set; } // Exemplo de propriedade, ajuste conforme necessário
    }
}
