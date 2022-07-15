using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos
{
    public class ServicoCategoriasDeVeiculos
    {
        private IRepositorioCategoriaDeVeiculos repositorioCategoriaDeVeiculos;

        public ServicoCategoriasDeVeiculos(IRepositorioCategoriaDeVeiculos repositorioCategoriaDeVeiculos)
        {
            this.repositorioCategoriaDeVeiculos = repositorioCategoriaDeVeiculos;
        }

        public Result<CategoriaDeVeiculos> Inserir(CategoriaDeVeiculos arg)
        {
            Log.Logger.Debug("Tentando inserir categoria... {@f}", arg);

            Result resultadoValidacao = ValidarCategoriaDeVeiculos(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar inserir a Categoria {CategoriaDeVeiculosId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCategoriaDeVeiculos.Inserir(arg);

                Log.Logger.Information("Categoria {CategoriaDeVeiculosId} inserida com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar inserir a categoria";

                Log.Logger.Error(ex, msgErro + "{CategoriaDeVeiculosId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<CategoriaDeVeiculos> Editar(CategoriaDeVeiculos arg)
        {
            Log.Logger.Debug("Tentando editar categoria... {@f}", arg);

            Result resultadoValidacao = ValidarCategoriaDeVeiculos(arg);

            if (resultadoValidacao.IsFailed)
            {
                foreach (var erro in resultadoValidacao.Errors)
                {
                    Log.Logger.Warning("Falha ao tentar editar a Categoria {CategoriaDeVeiculosId} - {Motivo}",
                       arg.Id, erro.Message);
                }

                return Result.Fail(resultadoValidacao.Errors);
            }

            try
            {
                repositorioCategoriaDeVeiculos.Editar(arg);

                Log.Logger.Information("Categoria {CategoriaDeVeiculosId} editada com sucesso", arg.Id);

                return Result.Ok(arg);
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar editar a categoria";

                Log.Logger.Error(ex, msgErro + "{CategoriaDeVeiculosId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result Excluir(CategoriaDeVeiculos arg)
        {
            Log.Logger.Debug("Tentando excluir categoria... {@f}", arg);

            try
            {
                repositorioCategoriaDeVeiculos.Excluir(arg);

                Log.Logger.Information("Categoria {CategoriaDeVeiculosId} excluída com sucesso", arg.Id);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar excluir a categoria";

                Log.Logger.Error(ex, msgErro + "{CategoriaDeVeiculosId}", arg.Id);

                return Result.Fail(msgErro);
            }
        }

        public Result<List<CategoriaDeVeiculos>> SelecionarTodos()
        {
            try
            {
                return Result.Ok(repositorioCategoriaDeVeiculos.SelecionarTodos());
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar todos as categorias";

                Log.Logger.Error(ex, msgErro);

                return Result.Fail(msgErro);
            }
        }

        public Result<CategoriaDeVeiculos> SelecionarPorId(Guid id)
        {
            try
            {
                return Result.Ok(repositorioCategoriaDeVeiculos.SelecionarPorNumero(id));
            }
            catch (Exception ex)
            {
                string msgErro = "Falha no sistema ao tentar selecionar a categoria";

                Log.Logger.Error(ex, msgErro + "{CategoriaDeVeiculosId}", id);

                return Result.Fail(msgErro);
            }
        }

        private Result ValidarCategoriaDeVeiculos(CategoriaDeVeiculos arg)
        {
            ValidadorCategoriaDeVeiculos validador = new ValidadorCategoriaDeVeiculos();

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

        private bool NomeDuplicado(CategoriaDeVeiculos arg)
        {
            var categoriaDeVeiculosEncontrado = repositorioCategoriaDeVeiculos.SelecionarClientePorNome(arg.Nome);

            return categoriaDeVeiculosEncontrado != null &&
                   categoriaDeVeiculosEncontrado.Nome == arg.Nome &&
                   categoriaDeVeiculosEncontrado.Id != arg.Id;
        }
    }
}
