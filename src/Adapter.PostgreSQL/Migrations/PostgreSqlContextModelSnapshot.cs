﻿// <auto-generated />
using System;
using Adapter.PostgreSQL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Adapter.PostgreSQL.Migrations
{
    [DbContext(typeof(PostgreSqlContext))]
    partial class PostgreSqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.CartaoCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("NomeNoCartao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("PessoaId")
                        .HasColumnType("integer");

                    b.Property<int>("TipoCartao")
                        .HasColumnType("integer");

                    b.Property<string>("Vencimento")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("CartaoCredito");
                });

            modelBuilder.Entity("Core.Entities.Dominio", b =>
                {
                    b.Property<string>("Chave")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int>("DominioId")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Chave", "DominioId");

                    b.ToTable("Dominio");
                });

            modelBuilder.Entity("Core.Entities.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FormaPagamento")
                        .HasMaxLength(30)
                        .HasColumnType("integer");

                    b.Property<int>("QuantidadeProdutos")
                        .HasColumnType("integer");

                    b.Property<int>("StatusPedido")
                        .HasMaxLength(30)
                        .HasColumnType("integer");

                    b.Property<int>("Usuario")
                        .HasColumnType("integer");

                    b.Property<int>("UsuarioEndereco")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorEntrega")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Core.Entities.PedidoCartaoCredito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CartaoCreditoId")
                        .HasColumnType("integer");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CartaoCreditoId");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoCartaoCredito");
                });

            modelBuilder.Entity("Core.Entities.PedidoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Observacao")
                        .HasColumnType("text");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.Property<decimal>("PrecoUnitario")
                        .HasColumnType("numeric");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoItem");
                });

            modelBuilder.Entity("Core.Entities.PedidoPix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoPix")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("PedidoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("PedidoPix");
                });

            modelBuilder.Entity("Core.Entities.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Categoria")
                        .HasColumnType("integer");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Estoque")
                        .HasColumnType("integer");

                    b.Property<decimal>("Preco")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Papel")
                        .HasColumnType("integer");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SobreNome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Core.Entities.UsuarioEndereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("UsuarioEndereco");
                });

            modelBuilder.Entity("Core.Entities.CartaoCredito", b =>
                {
                    b.HasOne("Core.Entities.Usuario", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Core.Entities.PedidoCartaoCredito", b =>
                {
                    b.HasOne("Core.Entities.CartaoCredito", "CartaoCredito")
                        .WithMany()
                        .HasForeignKey("CartaoCreditoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CartaoCredito");

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Core.Entities.PedidoItem", b =>
                {
                    b.HasOne("Core.Entities.Pedido", "Pedido")
                        .WithMany("PedidoItens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Core.Entities.PedidoPix", b =>
                {
                    b.HasOne("Core.Entities.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("Core.Entities.UsuarioEndereco", b =>
                {
                    b.HasOne("Core.Entities.Usuario", "Usuario")
                        .WithMany("UsuarioEnderecos")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Core.Entities.Pedido", b =>
                {
                    b.Navigation("PedidoItens");
                });

            modelBuilder.Entity("Core.Entities.Usuario", b =>
                {
                    b.Navigation("UsuarioEnderecos");
                });
#pragma warning restore 612, 618
        }
    }
}
