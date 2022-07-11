using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloMotorista
{
    [TestClass]
    public class CondutorTest
    {
        private readonly Condutor condutor;
        private readonly ValidadorCondutor validador;

        public CondutorTest()
        {
            condutor = new Condutor()
            {
                Nome = "Pedro",
                CNH = "11111111111",
                Validade_CNH = new(2024 / 2 / 2),
                CPF = "22222222222",
                Telefone = "4999999999",
                Email = "tales@gmail.com",
                Edereco = "Rua Anápolis N° 600",
                Cliente = new Cliente("Tales O Lider", "08811833340", "tipoTest", "taleslider@gmail.com", "23432434344"),
            };
            validador = new ValidadorCondutor();
        }

        [TestMethod]
        public void Nome_Do_Condutor_É_Obrigatório()
        {
            //arrenge
            condutor.Nome = null;

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_Do_Condutor_Deve_Ser_Valido()
        {
            //arrenge
            condutor.Nome = "@@2344";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void Nome_Do_Condutor_Deve_Ser_Maior_Que_Dois()
        {
            //arrenge
            condutor.Nome = "o";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Nome);
        }

        [TestMethod]
        public void CPF_OU_CNPJ_Do_Condutor_É_Obrigatório()
        {
            //arrenge
            condutor.CPF = null;

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void CPF_OU_CNPJ_Do_Condutor_Deve_Ter_No_Minimo_11_digitos()
        {
            //arrenge
            condutor.CPF = "123456789";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void CPF_OU_CNPJ_Do_Condutor_Deve_Ter_No_Maximo_14_digitos()
        {
            //arrenge
            condutor.CPF = "123456789102345";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.CPF);
        }

        [TestMethod]
        public void Email_Do_Condutor_É_Obrigatório()
        {
            //arrenge
            condutor.Email = null;

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Email_Do_Condutor_Deve_Ser_Valido()
        {
            condutor.Email = "pedro";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Email_Do_Condutor_Deve_Ser_Maior_Que_Cinco_Caracteres()
        {
            condutor.Email = "test";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Email);
        }

        [TestMethod]
        public void Telefone_Do_Condutor_É_Obrigatório()
        {
            //arrenge
            condutor.Telefone = null;

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Telefone_Do_Condutor_Deve_Ser_Valido()
        {
            condutor.Telefone = "opd@#";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }

        [TestMethod]
        public void Telefone_Do_Condutor_Deve_Ser_Maior_Que_Dez_Caracteres()
        {
            condutor.Telefone = "32242525";

            //action
            var outroResultado = validador.TestValidate(condutor);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(condutor => condutor.Telefone);
        }
    }
}
