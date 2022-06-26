using System.Text.RegularExpressions;
using FluentValidation;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;

namespace Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos
{
    public class ValidadorDeVeiculos : AbstractValidator<CategoriaDeVeiculos>
    {
        public ValidadorDeVeiculos()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);
        }
    }
}
