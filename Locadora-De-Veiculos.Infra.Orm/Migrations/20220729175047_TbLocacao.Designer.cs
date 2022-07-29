﻿// <auto-generated />
using System;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora_De_Veiculos.Infra.Orm.Migrations
{
    [DbContext(typeof(LocaDoraDeVeiculosDbContext))]
    [Migration("20220729175047_TbLocacao")]
    partial class TbLocacao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloCliente.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF_CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tipo_Cliente")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TbCliente");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNH")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Edereco")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Validade_CNH")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("TbCondutor");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloFuncionario.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnType("datetime");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TipoFuncionario")
                        .IsRequired()
                        .HasColumnType("varchar(60)");

                    b.HasKey("Id");

                    b.ToTable("TbFuncionario");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos.CategoriaDeVeiculos", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TbCategoriaVeiculo");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CondutorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataFinalPrevista")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime");

                    b.Property<Guid>("FuncionarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("NomeDoPlano")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<Guid>("PlanoDeCobrancaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VeiculoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("valorEstimado")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CondutorId");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("PlanoDeCobrancaId");

                    b.HasIndex("VeiculoId");

                    b.ToTable("TbLocacao");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca.PlanoDeCobranca", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaDeVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("PlanoDiario_ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoDiario_ValorPorKM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoKM_Livre_ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoKM_controlado_LimiteDeQuilometragem")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoKM_controlado_ValorDiario")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PlanoKM_controlado_ValorPorKM")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaDeVeiculosId");

                    b.ToTable("TbPlanoCobranca");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloTaxas.Taxa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<Guid?>("LocacaoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("TipoDeCobraca")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("LocacaoId");

                    b.ToTable("TbTaxas");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Ano")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Capacidade_tanque")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("CategoriaDeVeiculosId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(MAX)");

                    b.Property<decimal>("Km_total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("varchar(7)");

                    b.Property<int>("StatusVeiculo")
                        .HasColumnType("int");

                    b.Property<string>("Tipo_combustivel")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaDeVeiculosId");

                    b.ToTable("TbVeiculo");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloCondutor.Condutor", b =>
                {
                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos.CategoriaDeVeiculos", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloCliente.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloCondutor.Condutor", "Condutor")
                        .WithMany()
                        .HasForeignKey("CondutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloFuncionario.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca.PlanoDeCobranca", "PlanoDeCobranca")
                        .WithMany()
                        .HasForeignKey("PlanoDeCobrancaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloVeiculo.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Cliente");

                    b.Navigation("Condutor");

                    b.Navigation("Funcionario");

                    b.Navigation("PlanoDeCobranca");

                    b.Navigation("Veiculo");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca.PlanoDeCobranca", b =>
                {
                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos.CategoriaDeVeiculos", "CategoriaDeVeiculos")
                        .WithMany()
                        .HasForeignKey("CategoriaDeVeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaDeVeiculos");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloTaxas.Taxa", b =>
                {
                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloLocacao.Locacao", null)
                        .WithMany("Taxas")
                        .HasForeignKey("LocacaoId");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloVeiculo.Veiculo", b =>
                {
                    b.HasOne("Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos.CategoriaDeVeiculos", "CategoriaDeVeiculos")
                        .WithMany()
                        .HasForeignKey("CategoriaDeVeiculosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaDeVeiculos");
                });

            modelBuilder.Entity("Locadora_De_Veiculos.Dominio.ModuloLocacao.Locacao", b =>
                {
                    b.Navigation("Taxas");
                });
#pragma warning restore 612, 618
        }
    }
}
