using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.CQRS.Validation;
using System.Text.Json.Serialization;

namespace Domain.CQRS.Entities
{
    public sealed class Produto
    {


        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? CodigoBarra { get; set; }
        //public int CategoriaId { get; set; }
        //public Categoria Categoria { get; set; }
        public DateTime? DataCriacao { get; set; } 
        public DateTime? DataAtualizacao { get; set; }

        public ICollection<Estoque>? Estoque { get; set; }






        public Produto(string? nome, string? descricao, string? codigoBarra, DateTime? dataCriacao, DateTime? dataAtualizacao)
        {
            ValidateDomain(nome, descricao, codigoBarra, dataCriacao, dataAtualizacao);
        }


        public Produto()
        {
        }

        [JsonConstructor]
        public Produto(int produtoid, string? nome, string? descricao, string? codigoBarra, DateTime? dataCriacao, DateTime? dataAtualizacao)
        {
            DomainValidation.When(produtoid < 0, "Valor inválido.");
            ProdutoId = produtoid;
            ValidateDomain(nome, descricao, codigoBarra, dataCriacao, dataAtualizacao);
        }


        public void Update(string? nome, string? descricao, string? codigoBarra, DateTime? dataCriacao, DateTime? dataAtualizacao)
        {
            ValidateDomain(nome, descricao, codigoBarra, dataCriacao, dataAtualizacao);
        }


        public void ValidateDomain(string? nome, string? descricao, string? codigoBarra,
            DateTime? dataCriacao, DateTime? dataAtualizacao)

        {

                 DomainValidation.When(string.IsNullOrWhiteSpace(nome),
                "Nome inválido. O nome é obrigatório.");

                DomainValidation.When(descricao?.Length < 3,
                "Descrição inválida , muito curto, mínimo de 3 caracteres");




            Nome = nome;
            Descricao = descricao;
            CodigoBarra = codigoBarra;
            DataCriacao = dataCriacao;
            DataAtualizacao = dataAtualizacao;

        }


      

    }


        }
    
    

