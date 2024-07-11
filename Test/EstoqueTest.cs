using Domain.CQRS.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class EstoqueTest
    {
        private readonly Mock<IEstoqueRepository> _estoqueRepository;


        public EstoqueTest()
        {
          _estoqueRepository = new Mock<IEstoqueRepository>();
        
        }

        [Fact]
        public async Task EstoqueCreate_test()
        {
              int produtoid = 1;
            var qteestoque = 100;
            var estoquemaximo = 100;
            var estoqueminimo = 10;
            var saldoanterior = 0;
            var localizacao = "teste de material";
            var valorunitario=120;
         //   _estoqueRepository.Setup(x=>x.GetEntityById(produtoid)).ReturnsAsync(new E)



        }
    }
}


