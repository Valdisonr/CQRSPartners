using Domain.CQRS.Entities;
using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infra.Data.CQRS.Repositories
{
    public class ProdutoRepository : GenericRepository<Produto>, IProdutoRepository
    {
        private readonly ContextoDB _contextoDB;

        public ProdutoRepository(ContextoDB contexto) : base(contexto)
        {
            _contextoDB = contexto;
        }

        public async Task AddProduto(Produto produto)
        {
            try
            {
                var newProduto = new Produto()
                {
                    Nome = produto.Nome.ToUpper(),
                    Descricao = produto.Descricao.ToUpper(),
                    CodigoBarra = produto.CodigoBarra,
                    DataCriacao = DateTime.Now,
                };

                // Adiciona o newProduto ao contexto
                _contextoDB.Set<Produto>().Add(newProduto);
                await _contextoDB.SaveChangesAsync(); // Salva mudanças de forma assíncrona

                // Agora que o newProduto foi salvo, podemos obter o ProdutoId gerado
                var produtoId = newProduto.ProdutoId;

                // Cria o novo Estoque usando o ProdutoId obtido
                var newEstoque = new Estoque()
                {
                    ProdutoId = produtoId,
                    DtCreate = DateTime.Now
                };

                _contextoDB.Set<Estoque>().Add(newEstoque);
                await _contextoDB.SaveChangesAsync(); // Salva mudanças de forma assíncrona para persistir o Estoque
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar produto com estoque: {ex.Message}");
            }
        }
    }
}
