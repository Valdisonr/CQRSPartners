﻿// <auto-generated />
using System;
using Infra.Data.CQRS.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.Data.CQRS.Migrations
{
    [DbContext(typeof(ContextoDB))]
    [Migration("20240703191602_int")]
    partial class @int
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Domain.CQRS.Entities.Estoque", b =>
                {
                    b.Property<int>("EstoqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("EstoqueId"));

                    b.Property<DateTime?>("DtCreate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(5419));

                    b.Property<DateTime?>("DtUpdate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(5709));

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime?>("DtUpdate"));

                    b.Property<int?>("EstoqueMaximo")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(9)
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("EstoqueMinimo")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(9)
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Localizacao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<int?>("QtdEstoque")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(9)
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("SaldoAnterior")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(9)
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<decimal>("ValorUnitario")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasDefaultValue(0.0m);

                    b.HasKey("EstoqueId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("Estoque");

                    b.HasData(
                        new
                        {
                            EstoqueId = 1,
                            EstoqueMaximo = 200,
                            EstoqueMinimo = 10,
                            Localizacao = "A1",
                            ProdutoId = 1,
                            QtdEstoque = 100,
                            SaldoAnterior = 90,
                            ValorUnitario = 50.0m
                        },
                        new
                        {
                            EstoqueId = 2,
                            EstoqueMaximo = 250,
                            EstoqueMinimo = 15,
                            Localizacao = "A2",
                            ProdutoId = 2,
                            QtdEstoque = 150,
                            SaldoAnterior = 140,
                            ValorUnitario = 55.0m
                        },
                        new
                        {
                            EstoqueId = 3,
                            EstoqueMaximo = 300,
                            EstoqueMinimo = 20,
                            Localizacao = "A3",
                            ProdutoId = 3,
                            QtdEstoque = 200,
                            SaldoAnterior = 190,
                            ValorUnitario = 60.0m
                        });
                });

            modelBuilder.Entity("Domain.CQRS.Entities.Produto", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<string>("CodigoBarra")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3223));

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ProdutoId");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            ProdutoId = 1,
                            CodigoBarra = "123456",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3552),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3549),
                            Descricao = "Descrição do Produto 1",
                            Nome = "Produto 1"
                        },
                        new
                        {
                            ProdutoId = 2,
                            CodigoBarra = "654321",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3560),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3560),
                            Descricao = "Descrição do Produto 2",
                            Nome = "Produto 2"
                        },
                        new
                        {
                            ProdutoId = 3,
                            CodigoBarra = "789012",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3562),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3562),
                            Descricao = "Descrição do Produto 3",
                            Nome = "Produto 3"
                        },
                        new
                        {
                            ProdutoId = 4,
                            CodigoBarra = "345678",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3563),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3563),
                            Descricao = "Descrição do Produto 4",
                            Nome = "Produto 4"
                        },
                        new
                        {
                            ProdutoId = 5,
                            CodigoBarra = "901234",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3565),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3564),
                            Descricao = "Descrição do Produto 5",
                            Nome = "Produto 5"
                        },
                        new
                        {
                            ProdutoId = 6,
                            CodigoBarra = "567890",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3566),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3566),
                            Descricao = "Descrição do Produto 6",
                            Nome = "Produto 6"
                        },
                        new
                        {
                            ProdutoId = 7,
                            CodigoBarra = "234567",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3567),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3567),
                            Descricao = "Descrição do Produto 7",
                            Nome = "Produto 7"
                        },
                        new
                        {
                            ProdutoId = 8,
                            CodigoBarra = "890123",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3568),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3568),
                            Descricao = "Descrição do Produto 8",
                            Nome = "Produto 8"
                        },
                        new
                        {
                            ProdutoId = 9,
                            CodigoBarra = "456789",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3570),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3569),
                            Descricao = "Descrição do Produto 9",
                            Nome = "Produto 9"
                        },
                        new
                        {
                            ProdutoId = 10,
                            CodigoBarra = "012345",
                            DataAtualizacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3571),
                            DataCriacao = new DateTime(2024, 7, 3, 19, 16, 2, 198, DateTimeKind.Utc).AddTicks(3570),
                            Descricao = "Descrição do Produto 10",
                            Nome = "Produto 10"
                        });
                });

            modelBuilder.Entity("Domain.CQRS.Entities.Estoque", b =>
                {
                    b.HasOne("Domain.CQRS.Entities.Produto", "Produto")
                        .WithMany("Estoque")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Domain.CQRS.Entities.Produto", b =>
                {
                    b.Navigation("Estoque");
                });
#pragma warning restore 612, 618
        }
    }
}
