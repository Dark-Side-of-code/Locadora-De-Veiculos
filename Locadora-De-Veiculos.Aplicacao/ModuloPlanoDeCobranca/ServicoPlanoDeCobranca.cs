using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca
{
    public class ServicoPlanoDeCobranca
    {
        private IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public Result<PlanoDeCobranca> Inserir(PlanoDeCobranca arg)
        {
            Log.Logger.Debug("Tentando inserir Plano de cobrança... {@PlanoCobranca}", arg);

            Result resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir Plano de cobrança {PlanoCobrancaId} - {Motivo}",
                        arg.Id, erro.Message);
                }
                return Result.Fail(resultadoValidacao.Errors);
            }

            try 
            {
                repositorioPlanoDeCobranca.Inserir(arg);

                Log.Logger.Information("Plano de cobrança {PlanoCobranca} inserido com sucesso.", arg.Id);

                return Result.Ok(arg);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir plano de cobrança";
                
                Log.Logger.Error(ex, msgErro + "{PlanoCobranca}", arg.Id);

                return Result.Fail(msgErro);
            }
        }


        public Result<PlanoDeCobranca> Editar(PlanoDeCobranca arg)
        {
            Log.Logger.Debug("Tentando editar Plano de cobrança... {@PlanoCobranca}", arg);
           
            Result resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar Plano de cobrança {PlanoCobranca} - {Motivo}",
                        arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioPlanoDeCobranca.Editar(arg);

                Log.Logger.Information("Plano de cobrança {PlanoCobranca} editado com sucesso.", arg.Id);

                return Result.Ok(arg);
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao editar o veículo";

                Log.Logger.Error(ex, msgErro + "{PlanoCobranca}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(PlanoDeCobranca arg)
        {
            Log.Logger.Debug("Tentando excluir plano de cobrança... {@PlanoCobranca}", arg);

            try
            {
                repositorioPlanoDeCobranca.Excluir(arg);

                Log.Logger.Information("Plano de Cobrança {PlanoCobranca} excluído com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o plano de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobranca}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<PlanoDeCobranca>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarTodos());
            }
            catch(Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os plano de cobraça";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);

            }
        }

        public Result<PlanoDeCobranca> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioPlanoDeCobranca.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar os planos de cobrança";

                Log.Logger.Error(ex, msgErro + "{PlanoCobranca}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarPlanoDeCobranca(PlanoDeCobranca arg)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(arg);

            List<Error> erros = new List<Error>();

            foreach (ValidationFailure item in resultadoValidacao.Errors)
                erros.Add(new Error(item.ErrorMessage));

            if (NomeCategoriaDuplicado(arg))
                erros.Add(new Error("Nome da Categoria duplicado"));
            
            if (erros.Any())
                return Result.Fail(erros);

            return Result.Ok();
        }

        private bool NomeCategoriaDuplicado(PlanoDeCobranca arg)
        { 
            var planoEncontrado = repositorioPlanoDeCobranca.SelecionarNomeCategoria(arg.CategoriaDeVeiculos.Nome);

            return planoEncontrado != null &&
                   planoEncontrado.CategoriaDeVeiculos.Nome == arg.CategoriaDeVeiculos.Nome &&
                   planoEncontrado.CategoriaDeVeiculos.Id == arg.CategoriaDeVeiculos.Id &&
                   planoEncontrado.Id != arg.Id;
                  
        }
    }
}
