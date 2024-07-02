using Domain.CQRS.Interfaces;
using Infra.Data.CQRS.Repositories;

namespace Test.CQRS
{
    [TestClass]
    public class UnitTestProduto
    {
        [TestMethod]
       public async Task AddProduto()
        {

         IProdutoRepository _IProdutoRepository = new ProdutoRepository();
        }
        [TestMethod]
        public async Task listProduto()
        {

        }

        [TestMethod]
        public async Task  listProdutoId()
        {

        }

        [TestMethod]
        public async Task Delete()
        {

        }
    }
}