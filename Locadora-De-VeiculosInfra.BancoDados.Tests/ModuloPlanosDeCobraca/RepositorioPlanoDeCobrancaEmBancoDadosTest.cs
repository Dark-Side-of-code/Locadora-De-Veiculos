using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloPlanosDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Locadora_De_VeiculosInfra.BancoDados.Tests.ModuloPlanosDeCobraca
{
    [TestClass]
    public class RepositorioPlanoDeCobrancaEmBancoDadosTest
    {
        private PlanoDeCobranca planoDeCobranca;
        private CategoriaDeVeiculos categoriaDeVeiculos;
        public IRepositorioPlanoDeCobranca repositorio;
        public IRepositorioCategoriaDeVeiculos repositorioCategoria;

        public RepositorioPlanoDeCobrancaEmBancoDadosTest()
        {
            Db.ExecutarSql("DELETE FROM TBPLANOCOBRANCA; DBCC CHECKIDENT (TBPLANOCOBRANCA, RESEED, 0)");
            Db.ExecutarSql("DELETE FROM TBCATEGORIAVEICULO; DBCC CHECKIDENT (TBCATEGORIAVEICULO, RESEED, 0)");

            repositorio = new RepositorioPlanosDeCobrancaEmBancoDados();
            repositorioCategoria = new RepositorioCategoriaDeVeiculosEmBancoDados();
        }

        [TestMethod]
        public void Deve_inserir_PlanoDeCobrança()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("SUV");
            planoDeCobranca = new PlanoDeCobranca(100.00, 200.00, 300.00, 400.00, 500.00, 600.00, categoriaDeVeiculos);

            //action
            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(planoDeCobranca);

            var planoEncontrado = repositorio.SelecionarPorNumero(planoDeCobranca.Id);
           
            //assert
            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoDeCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_Editar_PlanoDeCobrança()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("SUV");
            planoDeCobranca = new PlanoDeCobranca(100.00, 200.00, 300.00, 400.00, 500.00, 600.00, categoriaDeVeiculos);
            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(planoDeCobranca);

            //action
            planoDeCobranca.PlanoDiario_ValorDiario = 200.00;
            planoDeCobranca.PlanoDiario_ValorPorKM = 300.00;
            planoDeCobranca.PlanoKM_Livre_ValorDiario = 400.00;
            planoDeCobranca.PlanoKM_controlado_LimiteDeQuilometragem = 500.00;
            planoDeCobranca.PlanoKM_controlado_ValorDiario = 600.00;
            planoDeCobranca.PlanoKM_controlado_ValorPorKM = 700.00;
            planoDeCobranca.CategoriaDeVeiculos = categoriaDeVeiculos;

            repositorio.Editar(planoDeCobranca);
            //assert
            var planoEncontrado = repositorio.SelecionarPorNumero(planoDeCobranca.Id);
            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoDeCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_Excluir_PlanoDeCobrança()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("SUV");
            planoDeCobranca = new PlanoDeCobranca(100.00, 200.00, 300.00, 400.00, 500.00, 600.00, categoriaDeVeiculos);
            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(planoDeCobranca);

            //action
            repositorio.Excluir(planoDeCobranca);
          

            //assert
            var planoEncontrado = repositorio.SelecionarPorNumero(planoDeCobranca.Id);
            Assert.IsNull(planoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_apenas_um_PlanoDeCobrança()
        {
            //arrange
            categoriaDeVeiculos = new CategoriaDeVeiculos("SUV");
            planoDeCobranca = new PlanoDeCobranca(100.00, 200.00, 300.00, 400.00, 500.00, 600.00, categoriaDeVeiculos);
            repositorioCategoria.Inserir(categoriaDeVeiculos);
            repositorio.Inserir(planoDeCobranca);

            //action
            var planoEncontrado = repositorio.SelecionarPorNumero(planoDeCobranca.Id);


            //assert
            Assert.IsNotNull(planoEncontrado);
            Assert.AreEqual(planoDeCobranca, planoEncontrado);
        }

        [TestMethod]
        public void Deve_selecionar_todos_um_PlanoDeCobrança()
        {
            //arrange
            CategoriaDeVeiculos categoria1 = new CategoriaDeVeiculos("SUV");
            PlanoDeCobranca plano1 = new PlanoDeCobranca(100.00, 200.00, 300.00, 400.00, 500.00, 600.00, categoria1);

            CategoriaDeVeiculos categoria2 = new CategoriaDeVeiculos("UBER");
            PlanoDeCobranca plano2 = new PlanoDeCobranca(200.00, 300.00, 400.00, 500.00, 600.00, 700.00, categoria2);

            CategoriaDeVeiculos categoria3 = new CategoriaDeVeiculos("POPULAR");
            PlanoDeCobranca plano3 = new PlanoDeCobranca(300.00, 400.00, 500.00, 600.00, 700.00, 800.00, categoria3);
            
            var repositorio = new RepositorioPlanosDeCobrancaEmBancoDados();

            repositorioCategoria.Inserir(categoria1);
            repositorio.Inserir(plano1);

            repositorioCategoria.Inserir(categoria2);
            repositorio.Inserir(plano2);

            repositorioCategoria.Inserir(categoria3);
            repositorio.Inserir(plano3);



            //action
            var planoDeCobranca = repositorio.SelecionarTodos();


            //assert
            Assert.AreEqual(3, planoDeCobranca.Count);

            Assert.AreEqual(plano1.Id, planoDeCobranca[0].Id);
            Assert.AreEqual(plano2.Id, planoDeCobranca[1].Id);
            Assert.AreEqual(plano3.Id, planoDeCobranca[2].Id);
        }
    }
}
