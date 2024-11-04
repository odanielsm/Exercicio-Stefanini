using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Services.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Commands;
    using Application.Queries;
    using MediatR;
    using Questao5.Application.Commands.Requests;

    namespace Infrastructure.Services.Controllers
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

            [HttpPost]
            [Route("movimentacao")]
            public async Task<IActionResult> RealizarMovimentacao([FromBody] MovimentacaoRequest request)
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
        }
    }


}
