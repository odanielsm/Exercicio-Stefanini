using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class MovimentacaoRequest
    {
        public string IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public string TipoMovimentacao { get; set; } // C para crédito, D para débito
    }

}
