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

            //RuleFor(x => x.Nome).Custom(TaxaComValoresDuplicados);
        }

        //private void TaxaComValoresDuplicados(string arg1, ValidationContext<Taxa> arg2)
        //{
        //    var array = ;
        //
        //    var dict = new Dictionary<string, int>();
        //
        //    foreach (var value in array)
        //    {
        //        dict.TryGetValue(value, out int count);
        //        dict[value] = count + 1;
        //    }
        //
        //    if (dict.Values.Any(x => x > 1))
        //        ctx.AddFailure(new ValidationFailure("Alternativas", "Respostas iguais foram informadas nas alternativas"));
        //}
    }
}
