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
                .NotEmpty()
                .MinimumLength(11)
                .MaximumLength(14);

            RuleFor(x => x.Tipo_Cliente)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty();

            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Telefone)
                .NotEmpty()
                .MinimumLength(10);
        }
    }
}
