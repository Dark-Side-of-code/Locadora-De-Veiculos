﻿using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario;
using Locadora_De_VeiculosInfra.BancoDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloFuncionario
{
    [TestClass]
    public class RepositorioFuncionarioEmBancoDadosTest : BaseIntegrationTest
    {
        private Funcionario funcionario;
        public IRepositorioFuncionario repositorio;

        public RepositorioFuncionarioEmBancoDadosTest()
        {           
            repositorio = new RepositorioFuncionarioEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_Funcionario()
        {
            //arrange
            funcionario = new Funcionario("Pedro lopes", "Pedro", "12345", 2.300, new(2022, 2, 9), "funcionario admin");
            repositorio.Inserir(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);


            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }


        [TestMethod]
        public void Deve_editar_informacoes_Funcionario()
        {
            //arrange
            funcionario = new Funcionario("Pedro lopes", "Pedro", "12345", 2.300, new(2022, 2, 9), "funcionario admin");
            repositorio.Inserir(funcionario);

            //action
            funcionario.Nome = "Carlos Daniel";
            funcionario.Login = "Carlos";
            funcionario.Senha = "54321";
            funcionario.Salario = 2.300;
            funcionario.DataAdmissao = new(2022, 5, 9);
            funcionario.TipoFuncionario = "funcionario admin";

            repositorio.Editar(funcionario);

            //assert
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);
            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_informacoes_Funcionario()
        {
            //arrange
            funcionario = new Funcionario("Pedro lopes", "Pedro", "1234", 2.300, new(2023, 8, 9), "funcionario admin");
            repositorio.Inserir(funcionario);

            //action           
            repositorio.Excluir(funcionario);

            //Assert
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);
            Assert.IsNull(funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_Funcionario()
        {
            //arrange
            funcionario = new Funcionario("Pedro lopes", "Pedro", "12345", 2.300, new(2022, 6, 9), "funcionario admin");
            repositorio.Inserir(funcionario);

            //action           
            var funcionarioEncontrado = repositorio.SelecionarPorNumero(funcionario.Id);

            //Assert
           
            Assert.IsNotNull(funcionarioEncontrado);
            Assert.AreEqual(funcionario, funcionarioEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_um_Funcionario()
        {
            //arrange
            var p01 = new Funcionario("Pedro lopes", "Pedro", "12345", 2.300, new(2022, 1, 9), "funcionario admin");
            var p02 = new Funcionario("Carlos daniel", "Carlos", "67890", 2.300, new(2022, 1, 9), "funcionario admin");
            var p03 = new Funcionario("Tales de mileto", "Tales", "09870", 2.300, new(2022, 1, 9), "funcionario admin");
            
     
            var repositorio = new RepositorioFuncionarioEmBancoDados();
            repositorio.Inserir(p01);
            repositorio.Inserir(p02);
            repositorio.Inserir(p03);

            //action   
            var funcionarios = repositorio.SelecionarTodos();


            //Assert
            Assert.AreEqual(3, funcionarios.Count);

            Assert.AreEqual(p01.Nome, funcionarios[0].Nome);
            Assert.AreEqual(p02.Nome, funcionarios[1].Nome);
            Assert.AreEqual(p03.Nome, funcionarios[2].Nome);
        }



    }
}
