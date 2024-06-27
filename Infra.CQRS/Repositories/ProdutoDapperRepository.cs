using Dapper;
using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;

using System.Data;


namespace Infra.Data.CQRS.Repositories
{
    public class ProdutoDapperRepository : IProdutoDapperRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProdutoDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;

        }


        public async Task<Produto> GetDapperProdutoById(int id)
        {

            string query = "SELECT * FROM PRODUTO WHERE ProdutoId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Produto>(query, new { Id = id });
        
        
        }
        public async Task<IEnumerable<Produto>> GetDapperProdutos()
        {
            string query = "SELECT * FROM PRODUTO";
            return await _dbConnection.QueryAsync<Produto>(query);
            
        }
    }
}
