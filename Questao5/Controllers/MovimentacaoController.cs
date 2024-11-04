using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands;
using Questao5.Application.Queries;
using Questao5.Domain.ValueObjects;
using System.Threading.Tasks;

namespace Questao5.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> RegistrarMovimentacao([FromBody] RegistrarMovimentacaoCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Sucesso ? Ok(result) : BadRequest(result);
        }

        [HttpGet("consultar/{idcontacorrente}")]
        public async Task<IActionResult> ConsultarSaldo(string idcontacorrente)
        {
            var result = await _mediator.Send(new ConsultarSaldoQuery { Idcontacorrente = idcontacorrente });
            return result.Sucesso ? Ok(result) : BadRequest(result);
        }
    }
}
