using Questao5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentoRepository
    {
        Task Adicionar(Movimento movimento);
        Task<decimal> CalcularSaldo(string idContaCorrente);
        // Outros métodos necessários
    }

}
