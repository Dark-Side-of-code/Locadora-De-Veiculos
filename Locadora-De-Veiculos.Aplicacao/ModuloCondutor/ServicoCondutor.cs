using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloCondutor
{
    public class ServicoCondutor
    {
        private IRepositorioCondutor repositorioCondutor;
        private IContextoPersistencia contexto;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor, IContextoPersistencia contexto)
        {
            this.repositorioCondutor = repositorioCondutor;
            this.contexto = contexto;
        }

        public Result<Condutor> Inserir(Condutor arg)
        {
            Log.Logger.Debug("Tentando inserir condutor... {@Condutor}", arg);

            Result resultadoValidacao = ValidarCondutor(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Condutor {CondutorId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Inserir(arg);

                contexto.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} inserido com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> Editar(Condutor arg)
        {
            Log.Logger.Debug("Tentando editar condutor... {@Condutor}", arg);

            Result resultadoValidacao = ValidarCondutor(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar o Condutor {CondutorId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCondutor.Editar(arg);

                contexto.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} editado com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Condutor arg)
        {
            Log.Logger.Debug("Tentando excluir condutor... {@Condutor}", arg);

            try
            {
                repositorioCondutor.Excluir(arg);

                contexto.GravarDados();

                Log.Logger.Information("Condutor {CondutorId} excluído com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Condutor>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os condutores";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<Condutor> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCondutor.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCondutor(Condutor arg)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(arg);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (CPF_Duplicado(arg))
                erros.Add(new Error("CPF duplicado"));

            if (CNH_Duplicada(arg))
                erros.Add(new Error("CNH duplicada"));

            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool CPF_Duplicado(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return condutorEncontrado != null &&
                   condutorEncontrado.CPF == condutor.CPF &&
                   condutorEncontrado.Id != condutor.Id;
        }

        private bool CNH_Duplicada(Condutor condutor)
        {
            var condutorEncontrado = repositorioCondutor.SelecionarCondutorPorCPF(condutor.CPF);

            return condutorEncontrado != null &&
                   condutorEncontrado.CPF == condutor.CPF &&
                   condutorEncontrado.Id != condutor.Id;
        }
    }
}
