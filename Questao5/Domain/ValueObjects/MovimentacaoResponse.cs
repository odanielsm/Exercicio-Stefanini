using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.ValueObjects
{
    public class MovimentacaoResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public string IdMovimento { get; set; }
    }
}
