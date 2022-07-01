using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloVeiculo
{
    public class ValidadorVeiculo : AbstractValidator<Veiculo>
    {
        public ValidadorVeiculo()
        {
            RuleFor(x => x.Modelo)
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Placa)
                .NotEmpty()
                .MinimumLength(7);

            RuleFor(x => x.Marca)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Cor)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.Capacidade_tanque)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(x => x.Ano)
                .NotEmpty();

            RuleFor(x => x.Km_total)
                .GreaterThan(0)
                .NotEmpty();
        }
    }
}
