using Dapper;
using Questao5.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Questao5.Infrastructure.Database
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContaCorrenteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<ContaCorrente> ObterContaCorrenteAsync(string idcontacorrente)
        {
            var query = "SELECT * FROM contacorrente WHERE Idcontacorrente = @Idcontacorrente";
            return await _dbConnection.QueryFirstOrDefaultAsync<ContaCorrente>(query, new { Idcontacorrente = idcontacorrente });
        }

        public async Task AdicionarMovimentoAsync(Movimento movimento, string idempotencia)
        {
            var query = "INSERT INTO movimento (Idmovimento, Idcontacorrente, Datamovimento, Tipomovimento, Valor) VALUES (@Idmovimento, @Idcontacorrente, @Datamovimento, @Tipomovimento, @Valor)";
            await _dbConnection.ExecuteAsync(query, new { movimento.Idmovimento, movimento.Idcontacorrente, movimento.Datamovimento, movimento.Tipomovimento, movimento.Valor });
            
            var queryIdempotencia = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) VALUES (@ChaveIdempotencia, @Requisicao, @Resultado)";
            await _dbConnection.ExecuteAsync(queryIdempotencia, new { ChaveIdempotencia = idempotencia, Requisicao = movimento.ToString(), Resultado = "Sucesso" });

        }

        public async Task<bool> ExisteMovimentoAsync(string idempotencia)
        {
            var query = "SELECT COUNT(*) FROM idempotencia WHERE chave_idempotencia = @Idempotencia";
            var count = await _dbConnection.ExecuteScalarAsync<int>(query, new { Idempotencia = idempotencia });
            return count > 0;
        }

        public async Task<List<Movimento>> ObterMovimentosAsync(string idcontacorrente)
        {
            var query = "SELECT * FROM movimento WHERE Idcontacorrente = @Idcontacorrente";
            return (await _dbConnection.QueryAsync<Movimento>(query, new { Idcontacorrente = idcontacorrente })).ToList();
        }
    }
}
