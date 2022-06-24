using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Locadora_De_Veiculos.Dominio.ModuloTaxas
{
    public class ValidadorTaxa : AbstractValidator<Taxa>
    {
        public ValidadorTaxa()
        {
            RuleFor(x => x.Nome).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Descricao).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.TipoDeCobraca).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(x => x.Valor).NotNull().NotEmpty();
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
