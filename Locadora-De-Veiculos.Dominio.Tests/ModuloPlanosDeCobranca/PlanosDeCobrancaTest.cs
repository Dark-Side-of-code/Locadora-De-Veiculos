using FluentValidation.TestHelper;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.Tests.ModuloPlanosDeCobranca
{
    [TestClass]
    public class PlanosDeCobrancaTest
    {
        private readonly PlanoDeCobranca planoDeCobranca;
        private readonly ValidadorPlanoDeCobranca validador;

        public PlanosDeCobrancaTest()
        {
            planoDeCobranca = new()
            {
                CategoriaDeVeiculos = new("SUV"),
                PlanoDiario_ValorDiario = 200,
                PlanoDiario_ValorPorKM = 300,
                PlanoKM_Livre_ValorDiario = 400,
                PlanoKM_controlado_LimiteDeQuilometragem = 500,
                PlanoKM_controlado_ValorDiario = 600,
                PlanoKM_controlado_ValorPorKM = 700,

            };
            validador = new ValidadorPlanoDeCobranca();
        }

        [TestMethod]
        public void Categoria_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.CategoriaDeVeiculos = null;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.CategoriaDeVeiculos);
        }
        //
        //
        [TestMethod]
        public void PlanoDiario_ValorDiario_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.PlanoDiario_ValorDiario = 0.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiario_ValorDiario);
        }

        [TestMethod]
        public void PlanoDiario_ValorDiario_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            planoDeCobranca.PlanoDiario_ValorDiario = -1.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiario_ValorDiario);
        }
        //
        //
        [TestMethod]
        public void PlanoDiario_ValorPorKM_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.PlanoDiario_ValorPorKM = 0.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiario_ValorPorKM);
        }

        [TestMethod]
        public void PlanoDiario_ValorPorKM_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            planoDeCobranca.PlanoDiario_ValorPorKM = -1.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoDiario_ValorPorKM);
        }
        //
        // 
        [TestMethod]
        public void PlanoKM_Livre_ValorDiario_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.PlanoKM_Livre_ValorDiario = 0.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_Livre_ValorDiario);
        }

        [TestMethod]
        public void PlanoKM_Livre_ValorDiario_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            planoDeCobranca.PlanoKM_Livre_ValorDiario = -1.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_Livre_ValorDiario);
        }
        //
        //
        [TestMethod]
        public void PlanoKM_controlado_LimiteDeQuilometragem_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.PlanoKM_controlado_LimiteDeQuilometragem = 0.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_controlado_LimiteDeQuilometragem);
        }

        [TestMethod]
        public void PlanoKM_controlado_LimiteDeQuilometragem_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            planoDeCobranca.PlanoKM_Livre_ValorDiario = -1.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_controlado_LimiteDeQuilometragem);
        }
        //
        //
        [TestMethod]
        public void PlanoKM_controlado_ValorDiario_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.PlanoKM_controlado_ValorDiario = 0.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_controlado_ValorDiario);
        }

        [TestMethod]
        public void PlanoKM_controlado_ValorDiario_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            planoDeCobranca.PlanoKM_controlado_ValorDiario = -1.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_controlado_ValorDiario);
        }
        //
        //
        [TestMethod]
        public void PlanoKM_controlado_ValorPorKM_É_Obrigatório()
        {
            //arrenge
            planoDeCobranca.PlanoKM_controlado_ValorDiario = 0.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_controlado_ValorDiario);
        }

        [TestMethod]
        public void PlanoKM_controlado_ValorPorKM_Deve_Ser_Maior_Que_Zero()
        {
            //arrenge
            planoDeCobranca.PlanoKM_controlado_ValorDiario = -1.00;

            //action
            var outroResultado = validador.TestValidate(planoDeCobranca);

            //assert
            outroResultado.ShouldHaveValidationErrorFor(planoDeCobranca => planoDeCobranca.PlanoKM_controlado_ValorDiario);
        }


    }
}
