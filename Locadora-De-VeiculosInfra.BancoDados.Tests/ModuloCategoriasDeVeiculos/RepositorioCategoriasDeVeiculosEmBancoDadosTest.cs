using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_VeiculosInfra.BancoDados.Tests.Compartilhado;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloCategoriasDeVeiculos
{
    [TestClass]
    public class RepositorioCategoriasDeVeiculosEmBancoDadosTest : BaseIntegrationTest
    {
        private CategoriaDeVeiculos categoriaDeVeiculos;
        private IRepositorioCategoriaDeVeiculos repositorio;

        public RepositorioCategoriasDeVeiculosEmBancoDadosTest()
        {
            repositorio = new RepositorioCategoriaDeVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_novo_categoriaDeVeiculos()
        {
            //action
            categoriaDeVeiculos = new CategoriaDeVeiculos("nome");
            repositorio.Inserir(categoriaDeVeiculos);

            //assert
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorNumero(categoriaDeVeiculos.Id);

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
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorNumero(categoriaDeVeiculos.Id);

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
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorNumero(categoriaDeVeiculos.Id);
            Assert.IsNull(categoriaDeVeiculosEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_categoriaDeVeiculos()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("nome");
            repositorio.Inserir(categoriaDeVeiculos);

            //action
            var categoriaDeVeiculosEncontrado = repositorio.SelecionarPorNumero(categoriaDeVeiculos.Id);

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

        [TestMethod]
        public void Deve_selecionar_todos_os_registros()
        {
            //arrange
            var grupos = NovosGruposVeiculos();
            foreach (var g in grupos)
            {
                repositorio.Inserir(g);
            }

            //action
            var registrosEncontrados = repositorio.SelecionarTodos();

            //assert
            Assert.AreEqual(3, registrosEncontrados.Count);

            int posicao = 0;
            foreach (var g in grupos)
            {
                Assert.AreEqual(registrosEncontrados[posicao],g);
                posicao++;
            }
        }

        private List<CategoriaDeVeiculos> NovosGruposVeiculos()
        {
            var g1 = new CategoriaDeVeiculos("SUV");
            var g2 = new CategoriaDeVeiculos("Esportivo");
            var g3 = new CategoriaDeVeiculos("PCD");

            var lista = new List<CategoriaDeVeiculos>();
            lista.Add(g1);
            lista.Add(g2);
            lista.Add(g3);

            return lista;
        }
    }
}
