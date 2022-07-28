using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloDevolucao
{
    public class ValidadorDevolucao : AbstractValidator<Devolucao>
    {
        public ValidadorDevolucao()
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

            RuleFor(x => x.Data_Inicio_Locacao)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Data_Final_Prevista)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Data_Da_Entrega)
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

            RuleFor(x => x.TaxaSelecionada)
                .NotNull()
                .NotEmpty();
           
            
            RuleFor(x => x.ValorTotal)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
