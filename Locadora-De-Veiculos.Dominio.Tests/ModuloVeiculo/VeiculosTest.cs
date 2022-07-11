using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloVeiculo
{
    [TestClass]
    public class VeiculosTest
    {
        private readonly Veiculo veiculo;
        private readonly ValidadorVeiculo validador;

        public VeiculosTest()
        {
            veiculo = new Veiculo()
            {
                Modelo = "Ford KA GT",
                Placa = "AKATSUK",
                Marca = "Ford",
                Cor = "Azul",
                Tipo_combustivel = "Gasolina",
                Capacidade_tanque = 100,
                Ano = new DateTime(2010, 08, 09),
                Km_total = 10000,
                CategoriaDeVeiculos = new("Compacto")
            };
            validador = new ValidadorVeiculo();
        }

        [TestMethod]
        public void Modelo_Do_Veiculo_E_Obrigatorio()
        {
            //arrenge
            veiculo.Modelo = null;

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }

        [TestMethod]
        public void Modelo_Do_Veiculo_Deve_Ser_Maior_Que_Dois_Carateres()
        {
            //arrenge
            veiculo.Modelo = "x";

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Modelo);
        }

        [TestMethod]
        public void Placa_Do_Veiculo_E_Obrigatorio()
        {
            //arrenge
            veiculo.Placa = null;

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }

        [TestMethod]
        public void Placa_Do_Veiculo_Deve_Ser_Maior_Que_Sete_Carateres()
        {
            //arrenge
            veiculo.Placa = "ATR567";

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Placa);
        }

        [TestMethod]
        public void Marca_Do_Veiculo_E_Obrigatorio()
        {
            //arrenge
            veiculo.Marca = null;

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        [TestMethod]
        public void Marca_Do_Veiculo_Deve_Ser_Maior_Que_Dois_Carateres()
        {
            //arrenge
            veiculo.Marca = "A";

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        [TestMethod]
        public void Marca_Do_Veiculo_Nao_Pode_Ser_Invalido()
        {
            //arrenge
            veiculo.Marca = "A454ERTTY76767676Y";

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Marca);
        }

        [TestMethod]
        public void Cor_Do_Veiculo_E_Obrigatorio()
        {
            //arrenge
            veiculo.Cor = null;

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        [TestMethod]
        public void Cor_Do_Veiculo_Deve_Ser_Maior_Que_Dois_Carateres()
        {
            //arrenge
            veiculo.Cor = "A";

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        [TestMethod]
        public void Cor_Do_Veiculo_Nao_Pode_Ser_Invalido()
        {
            //arrenge
            veiculo.Cor = "A454ERTTY76767676Y";

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Cor);
        }

        [TestMethod]
        public void Capacidade_Tanque_Do_Veiculo_E_Obrigatorio()
        {
            //arrenge
            veiculo.Capacidade_tanque = 0;

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Capacidade_tanque);
        }

        public void Km_Total_Do_Veiculo_E_Obrigatorio()
        {
            //arrenge
            veiculo.Km_total = 0;

            //action
            var outroResultado = validador.TestValidate(veiculo);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(veiculo => veiculo.Km_total);
        }
    }
}
