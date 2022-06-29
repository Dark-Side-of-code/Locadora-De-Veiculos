using FluentValidation;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(x => x.Nome)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Login)
                .Matches(new Regex(@"^([^0-9]*)$"))
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Senha)
                .Matches("")
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.Salario)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(x => x.DataAdmissao)
                .LessThan(x => DateTime.Now)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TipoFuncionario)
                .NotEmpty()
                .NotNull();
            

        }            
    }
}
