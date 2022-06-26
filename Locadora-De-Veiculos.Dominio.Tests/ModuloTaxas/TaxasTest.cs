using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloTaxas
{
    [TestClass]
    public class TaxasTest
    {
        private readonly Taxa taxa;
        private readonly ValidadorTaxa validador;

        public TaxasTest()
        {
            taxa = new()
            {
                Nome = "Cadeirinha",
                Descricao = "Cadeirinha para criança de 6 anos",
                TipoDeCobraca = "Diaria",
                Valor = 100.00,
            };
            validador = new ValidadorTaxa();
        }

        [TestMethod]
         public void Nome_Da_Taxa_É_Obrigatorio()
         {
            //arrenge
            taxa.Nome = null;
           
            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Nome);
         }
        
        [TestMethod]
        public void Nome_Da_Taxa_Deve_Ser_Valido()
        {
            taxa.Nome = "p@@#$5";

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Nome);
        }

        [TestMethod]
        public void Nome_Da_Taxa_Deve_Ser_Maior_Que_Dois()
        {
            //arrenge
            taxa.Nome = "w";

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Nome);
        }

        [TestMethod]
        public void Descricao_Da_Taxa_É_Obrigatorio()
        {
            //arrenge
            taxa.Descricao = null;

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Descricao);
        }
        
        [TestMethod]
        public void Descricao_Da_Taxa_Deve_Ser_Valida()
        {
            taxa.Descricao = "p@@#$5";

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Descricao);
        }

        [TestMethod]
        public void Descricao_Da_Taxa_Deve_Ser_Maior_Que_Dois()
        {
            //arrenge
            taxa.Descricao = "w";

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Descricao);
        }

        [TestMethod]
        public void Tipo_De_Cobranca_Da_Taxa_É_Obrigatorio()
        {
            //arrenge
            taxa.TipoDeCobraca = null;

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.TipoDeCobraca);
        }

        [TestMethod]
        public void Tipo_De_Cobranca_Da_Taxa_Deve_Ser_Valida()
        {
            taxa.TipoDeCobraca = "p@@#$5";

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.TipoDeCobraca);
        }

        [TestMethod]
        public void Tipo_De_Cobranca_Da_Taxa_Deve_Maior_Que_Dois()
        {
            taxa.TipoDeCobraca = "p";

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.TipoDeCobraca);
        }

        [TestMethod]
        public void O_Valor_Da_Taxa_Não_Pode_Ser_Negativo()
        {
            //arrenge
            taxa.Valor = -1 ;

            //action
            var outroResultado = validador.TestValidate(taxa);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(taxa => taxa.Valor);
        }

    }
}
