using Questao5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.ValueObjects
{
    public class SaldoResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public string Tipo { get; set; }
        public decimal Saldo { get; set; }
        public ContaCorrente ContaCorrente { get; set; }
    }
}
