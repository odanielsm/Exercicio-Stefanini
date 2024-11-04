using MediatR;
using Questao5.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Application.Commands
{
    public class RegistrarMovimentacaoCommand : IRequest<MovimentacaoResponse>
    {
        public string Idempotencia { get; set; }
        public string Idcontacorrente { get; set; }
        public decimal Valor { get; set; }
        public string Tipomovimento { get; set; }
    }
}
