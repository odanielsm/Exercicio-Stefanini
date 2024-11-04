using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Questao5.Application.Handlers
{
    public class MovimentacaoCommandHandler : IRequestHandler<MovimentacaoRequest, MovimentacaoResponse>
    {
        public async Task<MovimentacaoResponse> Handle(MovimentacaoRequest request, CancellationToken cancellationToken)
        {
            // Lógica para processar a movimentação e gerar uma resposta
            var response = new MovimentacaoResponse
            {
                // Popule a resposta conforme necessário
            };
            return response;
        }
    }
}
