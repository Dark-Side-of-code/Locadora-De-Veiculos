using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Locadora_De_Veiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Descricao)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.TipoDeCobraca)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Valor)
                .GreaterThan(0)
                .NotEmpty();

        }
    }
}
