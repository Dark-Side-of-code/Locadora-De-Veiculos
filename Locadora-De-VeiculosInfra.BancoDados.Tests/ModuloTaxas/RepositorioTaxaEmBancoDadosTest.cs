using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloTaxas
{
    [TestClass]
    public class RepositorioTaxaEmBancoDadosTest
    {
        private Taxa taxa;
        private RepositorioTaxaEmBancoDados repositorio;

        public RepositorioTaxaEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TbTaxas; DBCC CHECKIDENT (TbTaxas, RESEED, 0)");
            repositorio = new RepositorioTaxaEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_taxa()
        {
            //action
            taxa = new Taxa("nome", "descricao", "tipoDeCobranca", 1);
            repositorio.Inserir(taxa);

            //assert
            var taxaEncontrado = repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEncontrado);
            Assert.AreEqual(taxa, taxaEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_taxa()
        {
            //arrange
            taxa = new Taxa("nome", "descricao", "tipoDeCobranca", 1);
            repositorio.Inserir(taxa);

            //action
            taxa.Nome = "Teste";
            repositorio.Editar(taxa);

            //assert
            var taxaEncontrado = repositorio.SelecionarPorId(taxa.Id);

            Assert.IsNotNull(taxaEncontrado);
            Assert.AreEqual(taxa, taxaEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_taxa()
        {
            //arrange
            taxa = new Taxa("nome", "descricao", "tipoDeCobranca", 1);
            repositorio.Inserir(taxa);

            //action           
            repositorio.Excluir(taxa);

            //assert
            var taxaEncontrado = repositorio.SelecionarPorId(taxa.Id);
            Assert.IsNull(taxaEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_taxa()
        {
            //arrange
            taxa = new Taxa("nome", "descricao", "tipoDeCobranca", 1);
            repositorio.Inserir(taxa);

            //action
            var taxaEncontrado = repositorio.SelecionarPorId(taxa.Id);

            //assert
            Assert.IsNotNull(taxaEncontrado);
            Assert.AreEqual(taxa, taxaEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_um_taxas()
        {
            //arrange
            var p01 = new Taxa("nomeA", "descricao", "tipoDeCobranca", 1);
            var p02 = new Taxa("nomeB", "descricao", "tipoDeCobranca", 2);
            var p03 = new Taxa("nomeC", "descricao", "tipoDeCobranca", 3);

            repositorio.Inserir(p01);
            repositorio.Inserir(p02);
            repositorio.Inserir(p03);

            //action
            var taxas = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, taxas.Count);

            Assert.AreEqual(p01.Nome, taxas[0].Nome);
            Assert.AreEqual(p02.Nome, taxas[1].Nome);
            Assert.AreEqual(p03.Nome, taxas[2].Nome);
        }
    }
}
