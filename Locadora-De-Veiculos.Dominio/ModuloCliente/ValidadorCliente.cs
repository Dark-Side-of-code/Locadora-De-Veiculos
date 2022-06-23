using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>
    {
        public ValidadorCliente()
        {
            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.CPF_CNPJ)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.CNH)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Validade_CNH)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Tipo_Cliente)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty();
        }
    }
}
