using Questao5.Domain.Entities;
using Questao5.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> ObterContaCorrenteAsync(string idcontacorrente);
        Task AdicionarMovimentoAsync(Movimento movimento, string idempotencia);
        Task<bool> ExisteMovimentoAsync(string idempotencia);
        Task<List<Movimento>> ObterMovimentosAsync(string idcontacorrente); // Método para obter todos os movimentos
    }
}
