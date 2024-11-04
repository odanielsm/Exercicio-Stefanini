using MediatR;
using Questao5.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Application.Queries
{
    public class ConsultarSaldoQuery : IRequest<SaldoResponse>
    {
        public string Idcontacorrente { get; set; }
    }
}
