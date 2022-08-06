using FluentResults;
using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloLocacao
{
    public class ServicoLocacao
    {
        private IRepositorioLocacao repositorioLocacao;
        private IContextoPersistencia contexto;
        private IGeradorRelatorioLocacao geradorRelatorio;

        public ServicoLocacao(IRepositorioLocacao repositorioLocacao, IContextoPersistencia contexto, IGeradorRelatorioLocacao geradorRalatorio)
        {
            this.repositorioLocacao = repositorioLocacao;
            this.contexto = contexto;
            this.geradorRelatorio = geradorRalatorio;
        }

        public Result<Locacao> Inserir(Locacao arg)
        {
            Log.Logger.Debug("Tentando inserir locacao... {@Locacao}", arg);

            Result resultadoValidacao = ValidarLocacao(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir o Locacao {LocacaoId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioLocacao.Inserir(arg);

                //arg.Veiculo.StatusVeiculo = false;

                contexto.GravarDados();
                geradorRelatorio.GeradorRalatorioPdf(arg);

                Log.Logger.Information("Locacao {LocacaoId} inserido com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir o locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(Locacao arg)
        {
            Log.Logger.Debug("Tentando excluir Locacao... {@Locacao}", arg);

            try
            {
                repositorioLocacao.Editar(arg);

                contexto.GravarDados();

                Log.Logger.Information("Locacao {LocacaoId} excluído com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir o Locacao";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> Devolucao(Locacao arg)
        {
            Log.Logger.Debug("Tentando devolver locação... {@Locacao}", arg);

            Result resultadoValidacao = ValidarLocacao(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar devolver Locação {@Locacao} -> Motivo: {erro}",
                        arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }
            try
            {
                repositorioLocacao.Editar(arg);

                contexto.GravarDados();

                Log.Logger.Information("Devolucao {@Locacao} concluida com sucesso.", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar devolver a locação";

                Log.Logger.Error(ex, msgErro + "{LocacaoId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<Locacao> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar o condutor";

                Log.Logger.Error(ex, msgErro + "{CondutorId}", id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<Locacao>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioLocacao.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos os Locacoes";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarLocacao(Locacao arg)
        {
            return Result.Ok();
        }

        public Locacao SelecionarLocacaoPorID(Guid id)
        {
            return repositorioLocacao.SelecionarLocacaoPorGuid(id);
        }
    }
}
