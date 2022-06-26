using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloCategoriasDeVeiculos
{
    [TestClass]
    public class CategoriasDeVeiculosTest
    {
        private readonly CategoriaDeVeiculos categoriaDeVeiculos;
        private readonly ValidadorDeVeiculos validador;

        public CategoriasDeVeiculosTest()
        {
            categoriaDeVeiculos = new()
            {
                Nome = "SUV"
            };
            validador = new ValidadorDeVeiculos();
        }

        [TestMethod]
        public void Nome_Da_categoria_É_Obrigatório()
        {
            //arrenge
            categoriaDeVeiculos.Nome = null;

            //action
            var outroResultado = validador.TestValidate(categoriaDeVeiculos);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(categoriaDeVeiculos => categoriaDeVeiculos.Nome);
        }

        [TestMethod]
        public void Nome_Da_Categoria_Deve_Ser_Valido()
        {
            //arrenge
            categoriaDeVeiculos.Nome = "p@@#$5";
            
            //action
            var outroResultado = validador.TestValidate(categoriaDeVeiculos);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(categoriaDeVeiculos => categoriaDeVeiculos.Nome);
        }

        [TestMethod]
        public void Nome_Da_Categoria_Deve_Ser_Maior_Que_Dois()
        {
            //arrenge
            categoriaDeVeiculos.Nome = "p";

            //action
            var outroResultado = validador.TestValidate(categoriaDeVeiculos);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(categoriaDeVeiculos => categoriaDeVeiculos.Nome);
        }
    }
}
