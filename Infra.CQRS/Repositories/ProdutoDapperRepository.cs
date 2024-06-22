using Dapper;
using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
    public class ProdutoDapperRepository : IProdutoDapperRepository
    {
        private readonly IDbConnection _dbconnection;

        public ProdutoDapperRepository(IDbConnection dbConnection)
        {
            _dbconnection = dbConnection;

        }

        public async Task<Produto> GetDapperProdutoById(int id)
        {
            string query = "SELECT * FROM PRODUTOS WHERE Id= @Id";
            return await _dbconnection.QueryFirstAsync<Produto>(query,new {Id=id});
            
        }

        public async Task<IEnumerable<Produto>> GetDapperProdutos()
        {
            string query = "SELECT * FROM PRODUTOS";
            return await _dbconnection.QueryAsync<Produto>(query);
            
        }
    }
}
