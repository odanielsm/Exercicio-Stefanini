using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public string Idmovimento { get; set; }
        public string Idcontacorrente { get; set; }
        public DateTime Datamovimento { get; set; } // Tipo DateTime para melhor manipulação
        public string Tipomovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
