using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
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

        public ServicoCliente(IRepositorioCliente repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Result<Cliente> Inserir(Cliente arg)
        {
            Log.Logger.Debug("Tentando inserir cliente... {@Cliente}", arg);

            Result resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Cliente {ClienteId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Inserir(arg);

                Log.Logger.Information("Cliente {ClienteId} inserido com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> Editar(Cliente arg)
        {
            Log.Logger.Debug("Tentando editar cliente... {@Cliente}", arg);

            Result resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Cliente {ClienteId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCliente.Editar(arg);

                Log.Logger.Information("Cliente {ClienteId} editado com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }
        public Result Excluir(Cliente arg)
        {
            Log.Logger.Debug("Tentando excluir cliente... {@Cliente}", arg);

            try
            {
                repositorioCliente.Excluir(arg);

                Log.Logger.Information("Cliente {ClienteId} excluído com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Cliente>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os clientes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Cliente> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCliente.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o cliente";

                Log.Logger.Error(ex, msgErro + "{ClienteId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCliente(Cliente arg)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(arg);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors) 
                erros.Add(new Error(item.ErrorMessage));

            if (CPF_CNPJ_Duplicado(arg))
                erros.Add(new Error("CPF duplicado"));

            return Result.Ok();
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
