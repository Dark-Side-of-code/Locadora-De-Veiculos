using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloCategoriasDeVeiculos
{
    [TestClass]
    public class RepositorioCategoriasDeVeiculosEmBancoDadosTest
    {
        private CategoriaDeVeiculos categoriaDeVeiculos;
        private RepositorioCategoriaDeVeiculosEmBancoDados repositorio;

        public RepositorioCategoriasDeVeiculosEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBCATEGORIAVEICULO; DBCC CHECKIDENT (TBCATEGORIAVEICULO, RESEED, 0)");
            repositorio = new RepositorioCategoriaDeVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_categoriaDeVeiculos()
        {
            //action
            categoriaDeVeiculos = new CategoriaDeVeiculos("nome");
            repositorio.Inserir(categoriaDeVeiculos);

            //assert
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorId(categoriaDeVeiculos.Id);

            Assert.IsNotNull(categoriaDeVeiculosEncontrado);
            Assert.AreEqual(categoriaDeVeiculos, categoriaDeVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_editar_informacoes_categoriaDeVeiculos()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("nome");
            repositorio.Inserir(categoriaDeVeiculos);

            //action
            categoriaDeVeiculos.Nome = "Teste";
            repositorio.Editar(categoriaDeVeiculos);

            //assert
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorId(categoriaDeVeiculos.Id);

            Assert.IsNotNull(categoriaDeVeiculosEncontrado);
            Assert.AreEqual(categoriaDeVeiculos, categoriaDeVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_excluir_categoriaDeVeiculos()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("nome");
            repositorio.Inserir(categoriaDeVeiculos);

            //action           
            repositorio.Excluir(categoriaDeVeiculos);

            //assert
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorId(categoriaDeVeiculos.Id);
            Assert.IsNull(categoriaDeVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_categoriaDeVeiculos()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("nome");
            repositorio.Inserir(categoriaDeVeiculos);

            //action
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorId(categoriaDeVeiculos.Id);

            //assert
            Assert.IsNotNull(categoriaDeVeiculosEncontrado);
            Assert.AreEqual(categoriaDeVeiculos, categoriaDeVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_um_categoriaDeVeiculoss()
        {
            //arrange
            var p01 = new CategoriaDeVeiculos("nome");
            var p02 = new CategoriaDeVeiculos("nomeA");
            var p03 = new CategoriaDeVeiculos("nomeB");

            repositorio.Inserir(p01);
            repositorio.Inserir(p02);
            repositorio.Inserir(p03);

            //action
            var categoriaDeVeiculoss = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, categoriaDeVeiculoss.Count);

            Assert.AreEqual(p01.Nome, categoriaDeVeiculoss[0].Nome);
            Assert.AreEqual(p02.Nome, categoriaDeVeiculoss[1].Nome);
            Assert.AreEqual(p03.Nome, categoriaDeVeiculoss[2].Nome);
        }
    }
}
