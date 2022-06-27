using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloCliente
{
    [TestClass]
    public class ClienteTest
    {
        private readonly Cliente cliente;
        private readonly ValidadorCliente validador;

        public ClienteTest()
        {
            cliente = new()
            {
                Nome = "Pedro",
                CPF_CNPJ = "08811833340",
                CNH = "12223336658",
                Validade_CNH = new(2022/8/20),
                Tipo_Cliente = "Pessoa Física",
                Email = "pedrolopes@hotmail.com",
                Telefone ="932255567",
            };
            validador = new ValidadorCliente();
        }
        
        [TestMethod]
        public void Nome_Do_Cliente_É_Obrigatório()
        {
            //arrenge
            cliente.Nome = null;

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Nome_Do_Cliente_Deve_Ser_Valido()
        {
            //arrenge
            cliente.Nome = "2225%%$";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void Nome_Do_Cliente_Deve_Ser_Maior_Que_Dois()
        {
            //arrenge
            cliente.Nome = "o";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Nome);
        }

        [TestMethod]
        public void CPF_OU_CNPJ_Do_Cliente_É_Obrigatório()
        {
            //arrenge
            cliente.CPF_CNPJ = null;

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF_CNPJ);
        }
        
        [TestMethod]
        public void CPF_OU_CNPJ_Do_Cliente_Deve_Ter_No_Minimo_11_digitos()
        {
            //arrenge
            cliente.CPF_CNPJ = "123456789";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF_CNPJ);
        }

        [TestMethod]
        public void CPF_OU_CNPJ_Do_Cliente_Deve_Ter_No_Maximo_14_digitos()
        {
            //arrenge
            cliente.CPF_CNPJ = "123456789102345";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CPF_CNPJ);
        }

        [TestMethod]
        public void CNH_Do_Cliente_É_Obrigatório()
        {
            //arrenge
            cliente.CNH = null;

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CNH);
        }

        [TestMethod]
        public void CNH_Do_Cliente_Deve_Ser_Valido()
        {
            //arrenge
            cliente.CNH = "abcdefg@#$r7";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CNH);
        }

        [TestMethod]
        public void CNH_Do_Cliente_Deve_Ter_No_Minimo_11_digitos()
        {
            //arrenge
            cliente.CNH = "123456789";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CNH);
        }

        [TestMethod]
        public void CNH_Do_Cliente_Deve_Ter_No_Maximo_14_digitos()
        {
            //arrenge
            cliente.CNH = "123456789102345";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.CNH);
        }

        [TestMethod]
        public void Data_Da_Validade_Da__Deve_Ser_Maior_Que_A_Data_Atual()
        {
            //arrenge
            cliente.Validade_CNH = new(2022/6/22);

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Validade_CNH);
        }

        [TestMethod]
        public void Tipo_Do_Cliente_É_Obrigatório()
        {
            //arrenge
            cliente.Tipo_Cliente = null;

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Tipo_Cliente);
        }

        [TestMethod]
        public void Email_Do_Cliente_É_Obrigatório()
        {
            //arrenge
            cliente.Email = null;

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        [TestMethod]
        public void Email_Do_Cliente_Deve_Ser_Valido()
        {
            cliente.Email = "pedro";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }
        
        [TestMethod]
        public void Email_Do_Cliente_Deve_Ser_Maior_Que_Cinco_Caracteres()
        {
            cliente.Email = "test";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Email);
        }

        [TestMethod]
        public void Telefone_Do_Cliente_É_Obrigatório()
        {
            //arrenge
            cliente.Telefone = null;

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Telefone_Do_Cliente_Deve_Ser_Valido()
        {
            cliente.Telefone = "opd@#";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }

        [TestMethod]
        public void Telefone_Do_Cliente_Deve_Ser_Maior_Que_Dez_Caracteres()
        {
            cliente.Telefone = "32242525";

            //action
            var outroResultado = validador.TestValidate(cliente);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(cliente => cliente.Telefone);
        }
    }
}
