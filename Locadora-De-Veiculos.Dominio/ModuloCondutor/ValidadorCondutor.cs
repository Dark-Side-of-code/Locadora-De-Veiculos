using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCondutor
{
    public class ValidadorCondutor : AbstractValidator<Condutor>
    {
        public ValidadorCondutor()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.CPF)
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(14);

            RuleFor(x => x.CNH)
                .NotEmpty()
                .Length(11);

            RuleFor(x => x.Validade_CNH)
                .GreaterThan(x => DateTime.Now)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .MinimumLength(10);

            RuleFor(x => x.Edereco)
                .NotEmpty()
                .MinimumLength(5);
        }
    }
}
