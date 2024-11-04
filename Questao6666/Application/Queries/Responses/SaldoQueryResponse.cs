using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Application.Queries.Responses
{
    public class SaldoQueryResponse
    {
        public int NumeroConta { get; set; }
        public string NomeTitular { get; set; }
        public DateTime DataHoraResposta { get; set; }
        public decimal Saldo { get; set; }
    }

}
