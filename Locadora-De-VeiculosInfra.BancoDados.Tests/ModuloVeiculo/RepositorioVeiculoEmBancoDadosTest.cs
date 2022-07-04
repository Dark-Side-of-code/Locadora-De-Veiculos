using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloVeiculo
{
    [TestClass]
    public class RepositorioVeiculoEmBancoDadosTest
    {
        private Veiculo veiculo;
        private CategoriaDeVeiculos categoriaDeVeiculos;
        public IRepositorioVeiculo repositorio;
        public IRepositorioCategoriaDeVeiculos repositorioCategoria;

        public RepositorioVeiculoEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBVEICULO; DBCC CHECKIDENT (TBVEICULO, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBCATEGORIAVEICULO; DBCC CHECKIDENT (TBCATEGORIAVEICULO, RESEED, 0)");
            repositorio = new RepositorioVeiculoEmBancoDados();
            repositorioCategoria = new RepositorioCategoriaDeVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_Veiculo()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("popular");
            veiculo = new Veiculo("Ford KA","ABC456L","Ford","Vermelho","Gasolina",40, new DateTime(2007, 9, 6), 1000,categoriaDeVeiculos);

            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorNumero(veiculo.Id);


            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo.Modelo, veiculoEncontrado.Modelo);
        }


        [TestMethod]
        public void Deve_editar_informacoes_Veiculo()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("popular");
            veiculo = new Veiculo("Ford KA", "ABC456L", "Ford", "Vermelho", "Gasolina", 40, new DateTime(2007, 9, 6), 1000, categoriaDeVeiculos);

            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(veiculo);

            //action
            veiculo.Modelo = "Ford KA GT";
            veiculo.Placa = "AKATSUK";
            veiculo.Marca = "Ford";
            veiculo.Cor = "Azul";
            veiculo.Tipo_combustivel = "Gasolina";
            veiculo.Capacidade_tanque = 100;
            veiculo.Ano = new DateTime(2010,08,09);
            veiculo.Km_total = 10000;
            veiculo.CategoriaDeVeiculos = categoriaDeVeiculos;

            repositorio.Editar(veiculo);

            //assert
            var veiculoEncontrado = repositorio.SelecionarPorNumero(veiculo.Id);
            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo.Modelo, veiculoEncontrado.Modelo);
        }

        [TestMethod]
        public void Deve_excluir_informacoes_Veiculo()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("popular");
            veiculo = new Veiculo("Ford KA", "ABC456L", "Ford", "Vermelho", "Gasolina", 40, new DateTime(2007, 9, 6), 1000, categoriaDeVeiculos);

            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(veiculo);

            //action           
            repositorio.Excluir(veiculo);

            //Assert
            var veiculoEncontrado = repositorio.SelecionarPorNumero(veiculo.Id);
            Assert.IsNull(veiculoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_Veiculo()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("popular");
            veiculo = new Veiculo("Ford KA", "ABC456L", "Ford", "Vermelho", "Gasolina", 40, new DateTime(2007, 9, 6), 1000, categoriaDeVeiculos);

            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(veiculo);

            //action           
            var veiculoEncontrado = repositorio.SelecionarPorNumero(veiculo.Id);

            //Assert

            Assert.IsNotNull(veiculoEncontrado);
            Assert.AreEqual(veiculo.Modelo, veiculoEncontrado.Modelo);
        }

        [TestMethod]
        public void Deve_selecionar_todos_um_Veiculo()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("popular");
            var p01 = new Veiculo("Ford KA", "ABC456L", "Ford", "Vermelho", "Gasolina", 40, new DateTime(2007, 9, 6), 1000, categoriaDeVeiculos);
            var p02 = new Veiculo("Ford KA", "ABC456L", "Ford", "Vermelho", "Gasolina", 40, new DateTime(2007, 9, 6), 1000, categoriaDeVeiculos);
            var p03 = new Veiculo("Ford KA", "ABC456L", "Ford", "Vermelho", "Gasolina", 40, new DateTime(2007, 9, 6), 1000, categoriaDeVeiculos);

            var repositorio = new RepositorioVeiculoEmBancoDados();
            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(p01);
            repositorio.Inserir(p02);
            repositorio.Inserir(p03);

            //action   
            var veiculos = repositorio.SelecionarTodos();


            //Assert
            Assert.AreEqual(3, veiculos.Count);

            Assert.AreEqual(p01.Modelo, veiculos[0].Modelo);
            Assert.AreEqual(p02.Modelo, veiculos[1].Modelo);
            Assert.AreEqual(p03.Modelo, veiculos[2].Modelo);
        }
    }
}
