using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;

namespace Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos
{
    public class ValidadorDeVeiculos : AbstractValidator<CategoriaDeVeiculos>
    {
        public ValidadorDeVeiculos()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
