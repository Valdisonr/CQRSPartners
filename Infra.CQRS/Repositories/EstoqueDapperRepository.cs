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
    public class EstoqueDapperRepository : IEstoqueDapperRepository
    {
        private readonly IDbConnection _dbConnection;


        public async Task<Estoque> GetDapperEstoqueById(int id)
        {
            string query = "SELECT * FROM ESTOQUE WHERE EstoqueId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Estoque>(query, new { Id = id });

            
        }

        public async Task<IEnumerable<Estoque>> GetDapperEstoques()
        {
            string query = "SELECT * FROM ESTOQUE";
            return await _dbConnection.QueryAsync<Estoque>(query);
        }



    }
}
