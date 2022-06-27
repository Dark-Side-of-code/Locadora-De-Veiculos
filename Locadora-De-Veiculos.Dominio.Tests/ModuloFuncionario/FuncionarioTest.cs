using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTest
    {
        private readonly Funcionario funcionario;
        private readonly ValidadorFuncionario validador;

        public FuncionarioTest()
        {
            funcionario = new Funcionario()
            {
                Nome = "Pedro",
                Login = "Pedro",
                Senha = "12345",
                Salario = 2.300,
                DataAdmissao = new(2022/2/2),
                TipoFuncionario = true,
            };
            validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nome_Do_Funcionario_É_Obrigatório()
        {
            //arrenge
            funcionario.Nome = null;

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Nome_Do_Funcionario_Deve_Ser_Valido()
        {
            //arrenge
            funcionario.Nome = "@@2344";

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Nome_Do_Funcionario_Deve_Ser_Maior_Que_Dois_Carateres()
        {
            //arrenge
            funcionario.Nome = "pe";

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Nome);
        }

        [TestMethod]
        public void Login_Do_Funcionario_É_Obrigatório()
        {
            //arrenge
            funcionario.Login = null;

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Login);
        }

        [TestMethod]
        public void Login_Do_Funcionario_Deve_Ser_Valido()
        {
            //arrenge
            funcionario.Login = "@@2344";

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Login);
        }

        [TestMethod]
        public void Login_Do_Funcionario_Deve_Ser_Maior_Que_Três_Caracteres()
        {
            //arrenge
            funcionario.Login = "eu";

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Login);
        }

        [TestMethod]
        public void Senha_Do_Funcionario_É_Obrigatório()
        {
            //arrenge
            funcionario.Senha = null;

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Senha);
        }

        [TestMethod]
        public void Senha_Do_Funcionario_Deve_Ter_Mais_Que_Cinco_Caracteres()
        {
            //arrenge
            funcionario.Senha = "123e";

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Senha);
        }

        [TestMethod]
        public void Salario_Do_Funcionario_É_Obrigatório()
        {
            //arrenge
            funcionario.Salario = 0.00;

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Salario);
        }

        [TestMethod]
        public void Salario_Do_Funcionario_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            funcionario.Salario = -1.00;

            //action
            var outroResultado = validador.TestValidate(funcionario);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(funcionario => funcionario.Salario);
        }
    }
}
