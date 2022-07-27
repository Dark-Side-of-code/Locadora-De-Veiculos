using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.Compartilhado;
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
        private IContextoPersistencia contexto;

        public ServicoFuncionario(IRepositorioFuncionario repositorioFuncionario, IContextoPersistencia contexto)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.contexto = contexto;
        }

        public Result<Funcionario> Inserir(Funcionario arg)
        {
            Log.Logger.Debug("Tentando inserir Funcionario... {@Funcionario}", arg);
           
            Result resultadoValidacao = ValidarFuncionario(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                        Log.Logger.Warning("Falha ao tentar inserir Funcionario {@Funcionario} -> Motivo: {erro}",
                            arg.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioFuncionario.Inserir(arg);

                contexto.GravarDados();

                Log.Logger.Information("Funcionario {@Funcionario} inserido com sucesso.", arg.Id);

                return Result.Ok(arg);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Funcionario> Editar(Funcionario arg)
        {
            Log.Logger.Debug("Tentando editar Funcionario... {@Funcionario}", arg);
           
            Result resultadoValidacao = ValidarFuncionario(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Funcionario {@Funcionario} -> Motivo: {erro}",
                        arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioFuncionario.Editar(arg);

                contexto.GravarDados();

                Log.Logger.Information("Funcionario {@Funcionario} editado com sucesso.", arg.Id);
                
                return Result.Ok(arg);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar o funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", arg.Id);

                return Result.Fail(msgErro);
            }  
        }

        public Result Excluir(Funcionario arg)
        {
            Log.Logger.Debug("Tentando excluir funcionário... {@Funcionario}", arg);

            try
            {
                repositorioFuncionario.Excluir(arg);

                contexto.GravarDados();

                Log.Logger.Information("Funcionário {FuncionarioId} excluído com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Funcionario>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarTodos());
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os fucionários";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }


        public Result<Funcionario> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioFuncionario.SelecionarPorNumero(id));
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o funcionário";

                Log.Logger.Error(ex, msgErro + "{FuncionarioId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarFuncionario(Funcionario arg)
        {
            var validador = new ValidadorFuncionario();

            var resultadoValidacao = validador.Validate(arg);

            List<Error> erros = new List<Error>(); // FluentResult

            foreach (ValidationFailure item in resultadoValidacao.Errors) //FluentValidation            
                erros.Add(new Error(item.ErrorMessage));

            if (NomeDuplicado(arg))
                erros.Add(new Error("Nome duplicado"));

            if (UsuarioDuplicado(arg))
                erros.Add(new Error("Login duplicado"));


            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
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
            var funcionarioEncontrado = repositorioFuncionario.SelecionarFuncionarioPorUsuario(arg.Login);

            return funcionarioEncontrado != null &&
                   funcionarioEncontrado.Login == arg.Login &&
                   funcionarioEncontrado.Id != arg.Id;
        }
    }
}
