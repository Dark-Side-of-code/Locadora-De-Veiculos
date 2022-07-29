using FluentResults;
using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloDevolucao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloDevolucao
{
    public class ServicoDevolucao
    {
        private IRepositorioDevolucao repositorioDevolucao;
        private IContextoPersistencia contexto;

        public ServicoDevolucao(IRepositorioDevolucao repositorioDevolucao, IContextoPersistencia contexto)
        {
            this.repositorioDevolucao = repositorioDevolucao;
            this.contexto = contexto;
        }
       
        public Result<Devolucao> Inserir(Devolucao arg)
        {
            Log.Logger.Debug("Tentando inserir devolução... {@Devolucao}", arg);

            Result resultadoValidacao = ValidarDevolucao(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach(var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Devolução {DevolucaoId - {Motivo}",
                        arg.Id, erro.Message);
                }
                
                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioDevolucao.Inserir(arg);

                contexto.GravarDados();

                Log.Logger.Information("Devolução {DevolucaoId} inserida com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a Devolução";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Devolucao arg)
        {
            Log.Logger.Debug("Tentando excluir Devolução... {@Devolucao}", arg);

            try
            {
                repositorioDevolucao.Excluir(arg);

                contexto.GravarDados();

                Log.Logger.Information("Devolucao {DevolucaoId} excluída com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a Devolução";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Devolucao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioDevolucao.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a Devolução";

                Log.Logger.Error(ex, msgErro + "{DevolucaoId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Devolucao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioDevolucao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Devolução";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarDevolucao(Devolucao arg)
        {
            return Result.Ok();
        }
    }
}
