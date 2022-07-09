using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private IRepositorioCliente repositorioCliente;
        private ILogger logger = Log.Logger;
        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente arg)
        {
            logger.Information("Tentando inserir Cliente... {@Cliente}", arg);
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Inserir(arg);
                logger.Information("Cliente {@Cliente} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Cliente {ClienteNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente arg)
        {
            logger.Information("Tentando editar Cliente... {@Cliente}", arg);
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioCliente.Editar(arg);
                logger.Information("Cliente {@Cliente} editado com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Cliente {ClienteNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente arg)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(arg);

            if (CPF_CNPJ_Duplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF duplicado"));

            return resultadoValidacao;
        }

        private bool CPF_CNPJ_Duplicado(Cliente arg)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCPF_CNPJ(arg.CPF_CNPJ);

            return clienteEncontrado != null &&
                   clienteEncontrado.CPF_CNPJ == arg.CPF_CNPJ &&
                   clienteEncontrado.Id != arg.Id;
        }
    }
}
