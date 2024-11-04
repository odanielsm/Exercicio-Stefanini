using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentacaoRequest : IRequest<MovimentacaoResponse>
    {
        // Propriedades do seu pedido (request)
        public decimal Valor { get; set; }
        public string TipoMovimentacao { get; set; }
        public int ContaId { get; set; }
        // Adicione outras propriedades necessárias
    }
}
