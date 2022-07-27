using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloLocacao
{
    public class ValidadorLocacao : AbstractValidator<Locacao>
    {
        public ValidadorLocacao()
        {

            RuleFor(x => x.Funcionario)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Cliente)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Condutor)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Categoria)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Veiculo)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.PlanoDeCobranca)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataInicio)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataFinalPrevista)
                .NotNull()
                .NotEmpty();

        }
    }
}
