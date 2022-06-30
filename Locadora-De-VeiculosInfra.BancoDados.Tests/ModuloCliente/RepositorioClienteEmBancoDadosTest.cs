using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloCliente
{
    [TestClass]
    public class RepositorioClienteEmBancoDadosTest
    {
        private Cliente cliente;
        private IRepositorioCliente repositorio;

        public RepositorioClienteEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBCLIENTE; DBCC CHECKIDENT (TBCLIENTE, RESEED, 0)");
            repositorio = new RepositorioClienteEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_cliente()
        {
            //action
            cliente = new Cliente("Tales O Lider", "08811833340", "34453242234", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");
            repositorio.Inserir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorNumero(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_clientes()
        {
            //arrange
            cliente = new Cliente("Tales O Lider", "08811833342", "34453242236", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");
            repositorio.Inserir(cliente);

            //action
            cliente.Nome = "Pedro Xerife";
            cliente.CPF_CNPJ = "08811833340";
            cliente.CNH = "34453242234";
            cliente.Validade_CNH = new(2022, 07, 25);
            cliente.Tipo_Cliente = "tipoTest";
            cliente.Email = "dsfsdfdsf@gmail.com";
            cliente.Telefone = "23432434344";

            repositorio.Editar(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorNumero(cliente.Id);

            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_clientes()
        {
            //arrange
            cliente = new Cliente("Tales O Lider", "08811833340", "34453242234", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");
            repositorio.Inserir(cliente);

            //action           
            repositorio.Excluir(cliente);

            //assert
            var clienteEncontrado = repositorio.SelecionarPorNumero(cliente.Id);
            Assert.IsNull(clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_clientes()
        {
            //arrange
            cliente = new Cliente("Tales O Lider", "08811833340", "34453242234", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");
            repositorio.Inserir(cliente);

            //action
            var clienteEncontrado = repositorio.SelecionarPorNumero(cliente.Id);

            //assert
            Assert.IsNotNull(clienteEncontrado);
            Assert.AreEqual(cliente, clienteEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_os_clientes()
        {
            //arrange
            //string nome, string cpf_cnpj, string cnh, DateTime validade_CNH, string tipo_Cliente, string email, string telefone
            var cliente1 = new Cliente("Tales O LiderA", "08811833341", "34453242231", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");
            var cliente2 = new Cliente("Tales O LiderE", "08811833342", "34453242232", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");
            var cliente3 = new Cliente("Tales O LiderOU", "08811833343", "34453242233", new(2022, 08, 23), "tipoTest", "taleslider@gmail.com", "23432434344");

            var repositorio = new RepositorioClienteEmBancoDados();
            repositorio.Inserir(cliente1);
            repositorio.Inserir(cliente2);
            repositorio.Inserir(cliente3);

            //action
            var clientes = repositorio.SelecionarTodos();

            //assert

            Assert.AreEqual(3, clientes.Count);

            Assert.AreEqual(cliente1.Nome, clientes[0].Nome);
            Assert.AreEqual(cliente2.Nome, clientes[1].Nome);
            Assert.AreEqual(cliente3.Nome, clientes[2].Nome);

        }
    }
}
