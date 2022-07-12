using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloFuncionario
{
    public class ServicoFuncionario
    {
        private IRepositorioFuncionario repositorioFuncionario;
        private ILogger logger = Log.Logger;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public ValidationResult Inserir(Funcionario arg)
        {
            logger.Information("Tentando inserir Funcionario... {@Funcionario}", arg);
            ValidationResult resultadoValidacao = ValidarFuncionario(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Inserir(arg);
                logger.Information("Funcionario {@Funcionario} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Funcionario {@Funcionario} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);


            return resultadoValidacao;
        }

        public ValidationResult Editar(Funcionario arg)
        {
            logger.Information("Tentando editar Funcionario... {@Funcionario}", arg);
            ValidationResult resultadoValidacao = ValidarFuncionario(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioFuncionario.Editar(arg);
                logger.Information("Funcionario {@Funcionario} editado com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Funcionario {@Funcionario} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);

            return resultadoValidacao;
        }

        private ValidationResult ValidarFuncionario(Funcionario arg)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(arg);

            if (NomeDuplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            if (UsuarioDuplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("Login", "Login duplicado"));

            return resultadoValidacao;
        }

        private bool NomeDuplicado(Funcionario arg)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorNome(arg.Nome);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Nome == arg.Nome &&
                   funcionarioEncontrado.Id != arg.Id;
        }

        private bool UsuarioDuplicado(Funcionario arg)
        {
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorUsuario(arg.TipoFuncionario);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.TipoFuncionario == arg.TipoFuncionario &&
                   funcionarioEncontrado.Id != arg.Id;
        }
    }
}
