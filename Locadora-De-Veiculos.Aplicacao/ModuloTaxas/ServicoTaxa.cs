using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloTaxas
{
    public class ServicoTaxa
    {
        private IRepositorioTaxa repositorioTaxa;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public Result<Taxa> Inserir(Taxa arg)
        {
            Log.Logger.Debug("Tentando inserir funcionário... {@f}", arg);

            Result resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Funcionário {TaxaId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Inserir(arg);

                Log.Logger.Information("Funcionário {TaxaId} inserido com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o funcionário";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> Editar(Taxa arg)
        {
            Log.Logger.Debug("Tentando editar funcionário... {@f}", arg);

            Result resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Funcionário {TaxaId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioTaxa.Editar(arg);

                Log.Logger.Information("Funcionário {TaxaId} editado com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o funcionário";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Taxa arg)
        {
            Log.Logger.Debug("Tentando excluir funcionário... {@f}", arg);

            try
            {
                repositorioTaxa.Excluir(arg);

                Log.Logger.Information("Funcionário {TaxaId} excluído com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o funcionário";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Taxa>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os funcionários";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Taxa> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioTaxa.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o funcionário";

                Log.Logger.Error(ex, msgErro + "{TaxaId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarTaxa(Taxa arg)
        {
            ValidadorTaxa validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(arg);

            List<Error> erros = new List<Error>(); //FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(arg))
                erros.Add(new Error("Nome duplicado"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeDuplicado(Taxa arg)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorNome(arg.Nome);

            return taxaEncontrada != null &&
                   taxaEncontrada.Nome == arg.Nome &&
                   taxaEncontrada.Id != arg.Id;
        }
    }
}
