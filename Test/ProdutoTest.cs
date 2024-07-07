using Domain.CQRS.Entities;

namespace Test
{
    public class ProdutoTest
    {
        [Fact]
        public void CriarProduto()
        {
            var  Nome = "nome 01";
            var Descricao = "descricao 01";
           var  CodigoBarra = "78910302";
           var DataCriacao =  DateTime.Now;
       

            var produto= new Produto(Nome, Descricao, CodigoBarra, DataCriacao);

            Assert.Equal(produto.Nome, Nome);
            Assert.Equal(produto.Descricao, Descricao);
            Assert.Equal(produto.CodigoBarra, CodigoBarra);
            Assert.Equal(produto.DataCriacao, DataCriacao);
  

        }
        
    }
}