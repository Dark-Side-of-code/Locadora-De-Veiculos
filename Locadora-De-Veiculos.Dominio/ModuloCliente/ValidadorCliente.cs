using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(x => x.CPF_CNPJ)
                .Matches(new Regex(@"^(((\d{3}).(\d{3}).(\d{3})-(\d{2}))?((\d{2}).(\d{3}).(\d{3})/(\d{4})-(\d{2}))?)*$"))
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(14);

            RuleFor(x => x.CNH)
                .Matches(new Regex(@"^-?[0-9][0-9,\.]+$"))
                .NotEmpty()
                .Length(11);

            RuleFor(x => x.Validade_CNH)
                .GreaterThan(x => DateTime.Now)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Tipo_Cliente)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Telefone)
                .Matches(new Regex(@"^\d{2}\d{4,5}\d{4}$"))
                .NotEmpty()
                .MinimumLength(10);
        }
    }
}
