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
                .NotEmpty()
                .GreaterThan(DateTime.Today);

            RuleFor(x => x.valorEstimado)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);

            /* DEVOLUÇÃO */
            RuleFor(x => x.DataFinalReal)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NivelDoTanque)
                .GreaterThanOrEqualTo(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.QuilometragemDoVeiculo)
                .GreaterThan(0)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Taxas)
             .NotNull()
             .NotEmpty();


            RuleFor(x => x.ValorTotal)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }


    }
}
