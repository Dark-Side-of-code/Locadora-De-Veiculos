using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca
{
    public class ValidadorPlanoDeCobranca : AbstractValidator<PlanoDeCobranca>
    {
        public ValidadorPlanoDeCobranca()
        {
            RuleFor(x => x.CategoriaDeVeiculos)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.PlanoDiario_ValorDiario)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PlanoDiario_ValorPorKM)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PlanoKM_Livre_ValorDiario)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PlanoKM_controlado_LimiteDeQuilometragem)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PlanoKM_controlado_ValorDiario)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.PlanoKM_controlado_ValorPorKM)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
