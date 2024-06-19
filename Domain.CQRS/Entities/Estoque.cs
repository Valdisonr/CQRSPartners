using Domain.CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.CQRS.Entities
{
    public sealed class Estoque
    {
        public int EstoqueId { get; private set; }
    
        public int? QtdEstoque { get; private set; }
        public int? EstoqueMinimo { get; private set; }
        public int? EstoqueMaximo { get; private set; }
        public int? SaldoAnterior { get; private set; }
        public string? Localizacao { get; private set; }
        public decimal ValorUnitario { get; private set; }
        public DateTime? DtCreate { get; private set; }
        public DateTime? DtUpdate { get; private set; }

        public int ProdutoId { get; private set; }
        public Produto? Produto { get; set; }





        // Construtor parametrizado com validações

        public Estoque(int produtoId, int? qtdEstoque, int? estoqueMinimo, int? estoqueMaximo,
                       int? saldoAnterior, string? localizacao, decimal valorUnitario, DateTime? dtCreate, DateTime? dtUpdate)
        {

        ValidateDomain(produtoId, qtdEstoque, estoqueMinimo, estoqueMaximo, saldoAnterior, localizacao, valorUnitario, dtCreate, dtUpdate);


        }


 
        public Estoque() { }


        [JsonConstructor]
        public Estoque(int estoqueId, int produtoId, int? qtdEstoque, int? estoqueMinimo, int? estoqueMaximo,
                       int? saldoAnterior, string? localizacao, decimal valorUnitario, DateTime? dtCreate, DateTime? dtUpdate)
        {

            DomainValidation.When(estoqueId < 0, "Valor inválido.");
            EstoqueId = estoqueId;
            ValidateDomain(produtoId, qtdEstoque, estoqueMinimo, estoqueMaximo, saldoAnterior, localizacao, valorUnitario, dtCreate, dtUpdate);


        }



        public void Update(int produtoId, int? qtdEstoque, int? estoqueMinimo, int? estoqueMaximo,
                   int? saldoAnterior, string? localizacao, decimal valorUnitario, DateTime? dtCreate, DateTime? dtUpdate)
        {
            ValidateDomain(produtoId, qtdEstoque, estoqueMinimo, estoqueMaximo, saldoAnterior, localizacao, valorUnitario, dtCreate, dtUpdate);
        }


        private void ValidateDomain( int produtoId, int? qtdEstoque, int? estoqueMinimo, int? estoqueMaximo,
                                    int? saldoAnterior, string? localizacao, decimal valorUnitario, DateTime? dtCreate, DateTime? dtUpdate)
        {
            //DomainValidation.When(estoqueId <= 0, "ID do Estoque inválido. O ID deve ser maior que zero.");
            DomainValidation.When(produtoId <= 0, "ID do Produto inválido. O ID deve ser maior que zero.");
            DomainValidation.When(valorUnitario < 0, "Valor unitário inválido. O valor deve ser maior ou igual a zero.");

            //EstoqueId = estoqueId;
            ProdutoId = produtoId;
            QtdEstoque = qtdEstoque;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
            SaldoAnterior = saldoAnterior;
            Localizacao = localizacao;
            ValorUnitario = valorUnitario;
            DtCreate = dtCreate ?? DateTime.UtcNow;
            DtUpdate = dtUpdate ?? DateTime.UtcNow;
        }


    } 
}
