using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public string IdContaCorrente { get; set; }
        public int Numero { get; set; }
        public string NomeTitular { get; set; }
        public bool Ativo { get; set; }
    }

}
