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
        public int EstoqueId { get; set; }
    
        public int? QtdEstoque { get; set; }
        public int? EstoqueMinimo { get; set; }
        public int? EstoqueMaximo { get; set; }
        public int? SaldoAnterior { get; set; }
        public string? Localizacao { get; set; }
        public decimal ValorUnitario { get; set; }
        public DateTime? DtCreate { get; set; }
        public DateTime? DtUpdate { get; set; }

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }





        // Construtor parametrizado com validações

        public Estoque(int produtoId, int? qtdEstoque, int? estoqueMinimo, int? estoqueMaximo,
                       int? saldoAnterior, string? localizacao, decimal valorUnitario)
        {

        ValidateDomain(produtoId, qtdEstoque, estoqueMinimo, estoqueMaximo, saldoAnterior, localizacao, valorUnitario);


        }

       

        public Estoque() { }


        [JsonConstructor]
        public Estoque(int estoqueId, int produtoId, int? qtdEstoque, int? estoqueMinimo, int? estoqueMaximo,
                       int? saldoAnterior, string? localizacao, decimal valorUnitario, DateTime? dtCreate, DateTime? dtUpdate)
        {

            DomainValidation.When(estoqueId < 0, "Valor inválido.");
            EstoqueId = estoqueId;
            ValidateDomain(produtoId, qtdEstoque, estoqueMinimo, estoqueMaximo, saldoAnterior, localizacao, valorUnitario);


        }



        public void UpdateEstoque(
            int produtoId,
            int qtdEstoque, 
            int estoqueMinimo,
            int estoqueMaximo,
            int? saldoAnterior, 
            string? localizacao,
            decimal valorUnitario)
        {
            ValidateDomain(produtoId, qtdEstoque, estoqueMinimo, 
        estoqueMaximo, saldoAnterior, localizacao, valorUnitario);
        }
        private void ValidateDomain(int produtoId, int? qtdEstoque, 
            int? estoqueMinimo, int? estoqueMaximo,
            int? saldoAnterior, string? localizacao, 
            decimal valorUnitario)


        {
            DomainValidation.When(produtoId <= 0, "ID do Produto inválido. O ID deve ser maior que zero.");
            DomainValidation.When(valorUnitario < 0, "Valor unitário inválido. O valor deve ser maior ou igual a zero.");
            DomainValidation.When(estoqueMinimo.HasValue && estoqueMinimo.Value < 0, "Estoque mínimo inválido. Deve ser maior ou igual a zero.");
            DomainValidation.When(estoqueMaximo.HasValue && estoqueMaximo.Value < 0, "Estoque máximo inválido. Deve ser maior ou igual a zero.");
            DomainValidation.When(estoqueMinimo.HasValue && estoqueMaximo.HasValue && estoqueMaximo.Value < estoqueMinimo.Value, "Estoque máximo não pode ser menor que estoque mínimo.");

            ProdutoId = produtoId;
            QtdEstoque = qtdEstoque;
            EstoqueMinimo = estoqueMinimo;
            EstoqueMaximo = estoqueMaximo;
            SaldoAnterior = saldoAnterior;
            Localizacao = localizacao;
            ValorUnitario = valorUnitario;
            
        }


    

    }
}
