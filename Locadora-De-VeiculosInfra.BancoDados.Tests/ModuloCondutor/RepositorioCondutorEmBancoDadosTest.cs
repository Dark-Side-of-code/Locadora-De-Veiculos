using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloCondutor;
using Locadora_De_VeiculosInfra.BancoDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloCondutor
{
    [TestClass]
    public class RepositorioCondutorEmBancoDadosTest : BaseIntegrationTest
    {
        private Condutor condutor;
        private Cliente cliente;

        private RepositorioCondutorEmBancoDados repositorioCondutor;
        private RepositorioClienteEmBancoDados repositorioCliente;


        public RepositorioCondutorEmBancoDadosTest()
        {
            repositorioCondutor = new RepositorioCondutorEmBancoDados();

            repositorioCliente = new RepositorioClienteEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_Condutor()
        {
            //Action
            cliente = new Cliente("Tales O Lider", "08811833342",  "tipoTest", "taleslider@gmail.com", "23432434344");
            condutor = new Condutor("nome", "11111111111", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);

            repositorioCliente.Inserir(cliente);

            repositorioCondutor.Inserir(condutor);

            //Assert
            var CondutorEncontrado = repositorioCondutor.SelecionarPorNumero(condutor.Id);

            Assert.IsNotNull(CondutorEncontrado);

            Assert.AreEqual(condutor.Nome, CondutorEncontrado.Nome);
        }

        [TestMethod]
        public void Deve_editar_informacoes_Condutor()
        {
            //arrange
            cliente = new Cliente("nome", "11111111111", "Pessoa Física", "email@gmail.com", "49999999999");
            condutor = new Condutor("nome", "11111111111", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);
            repositorioCliente.Inserir(cliente);

            repositorioCondutor.Inserir(condutor);

            //action
            condutor.Nome = "epocler";

            repositorioCondutor.Editar(condutor);

            //assert
            var CondutorEncontrado = repositorioCondutor.SelecionarPorNumero(condutor.Id);

            Assert.IsNotNull(CondutorEncontrado);
            Assert.AreEqual(condutor.Nome, CondutorEncontrado.Nome);
        }

        [TestMethod]
        public void Deve_excluir_Condutor()
        {
            //arrange
            cliente = new Cliente("nome", "11111111111", "Pessoa Física", "email@gmail.com", "49999999999");
            condutor = new Condutor("nome", "11111111111", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            //action           
            repositorioCondutor.Excluir(condutor);

            //assert
            var CondutorEncontrado = repositorioCondutor.SelecionarPorNumero(condutor.Id);
            Assert.IsNull(CondutorEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_Condutor()
        {
            //arrange
            cliente = new Cliente("nome", "11111111111", "Pessoa Física", "email@gmail.com", "49999999999");
            condutor = new Condutor("nome", "11111111111", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);
            repositorioCliente.Inserir(cliente);
            repositorioCondutor.Inserir(condutor);

            //action
            var CondutorEncontrado = repositorioCondutor.SelecionarPorNumero(condutor.Id);

            //assert
            Assert.IsNotNull(CondutorEncontrado);
            Assert.AreEqual(condutor.Nome, CondutorEncontrado.Nome);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_Condutor()
        {
            //arrange

            cliente = new Cliente("nome", "11111111111", "Pessoa Física", "email@gmail.com", "49999999999");
            condutor = new Condutor("nomeA", "11111111111", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);
            var condutor1 = new Condutor("nomeB", "11111111112", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);
            var condutor2 = new Condutor("nomeC", "11111111113", "11111111111", new(2023, 8, 9), "email@gmail.com", "49999999999", "Rua anápolis n°600", cliente);
            
            var repositorio = new RepositorioCondutorEmBancoDados();
            
            repositorioCliente.Inserir(cliente);
            
            repositorio.Inserir(condutor);
            repositorio.Inserir(condutor1);
            repositorio.Inserir(condutor2);
            
            //action
            var Condutors = repositorio.SelecionarTodos();
            
            //assert
            
            Assert.AreEqual(3, Condutors.Count);
            
            Assert.AreEqual(condutor.Nome, Condutors[0].Nome);
            Assert.AreEqual(condutor1.Nome, Condutors[1].Nome);
            Assert.AreEqual(condutor2.Nome, Condutors[2].Nome);
        }
    }
}
