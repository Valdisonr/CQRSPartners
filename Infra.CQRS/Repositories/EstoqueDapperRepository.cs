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

        public EstoqueDapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Estoque> GetDapperEstoqueById(int id)
        {
            string query = "SELECT * FROM ESTOQUE WHERE EstoqueId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Estoque>(query, new { Id = id });

            
        }

        public async Task<IEnumerable<Estoque>> GetDapperEstoques()
        {
           
            
                string query = @"
        SELECT E.*, P.*
        FROM ESTOQUE E
        INNER JOIN PRODUTO P ON E.PRODUTOID = P.PRODUTOID";

                var estoques = await _dbConnection.QueryAsync<Estoque, Produto, Estoque>(
                    query,
                    (estoque, produto) =>
                    {
                        estoque.Produto = produto; // Associar o produto ao estoque
                        return estoque;
                    },
                    splitOn: "ProdutoId" // Informa ao Dapper onde dividir os resultados para mapear corretamente
                );

                return estoques;
            }


            //    return await _dbConnection.QueryAsync<Produto>(query);

            //    string query = @"
            //SELECT e.*, p.*
            //FROM ESTOQUE e
            //INNER JOIN PRODUTO p ON e.ProdutoId = p.ProdutoId";

            //    return await _dbConnection.QueryAsync<Estoque, Produto, Estoque>(
            //        query,
            //        (estoque, produto) =>
            //        {
            //            estoque.Produto = produto; // Associar o produto ao estoque
            //            return estoque;
            //        },
            //        splitOn: "ProdutoId" // Informa ao Dapper onde dividir os resultados para mapear corretamente
            //    );
        }



    }

