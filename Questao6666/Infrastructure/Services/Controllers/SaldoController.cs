using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Services.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Application.Queries;
    using MediatR;
    using Questao5.Application.Queries.Requests;
    using Questao5.Infrastructure.Database.QueryStore.Requests;

    namespace Infrastructure.Services.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class SaldoController : ControllerBase
        {
            private readonly IMediator _mediator;

            public SaldoController(IMediator mediator)
            {
                _mediator = mediator;
            }

            [HttpGet]
            [Route("saldo/{idContaCorrente}")]
            public async Task<IActionResult> ConsultarSaldo(string idContaCorrente)
            {
                var request = new SaldoRequest { IdContaCorrente = idContaCorrente };
                var response = await _mediator.Send(request);
                return Ok(response);
            }
        }
    }


}
