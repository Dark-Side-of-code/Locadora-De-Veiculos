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
        private ILogger logger = Log.Logger;

        public ServicoCategoriasDeVeiculos(IRepositorioCategoriaDeVeiculos repositorioCategoriaDeVeiculos)
        {
            this.repositorioCategoriaDeVeiculos = repositorioCategoriaDeVeiculos;
        }

        public ValidationResult Inserir(CategoriaDeVeiculos arg)
        {
            logger.Information("Tentando inserir Categoria de veiculos... {@CategoriaDeVeiculos}", arg);
            var resultadoValidacao = ValidarCategoriaDeVeiculos(arg);

            if (resultadoValidacao.IsValid) 
            {
                repositorioCategoriaDeVeiculos.Inserir(arg);
                logger.Information("Categoria de veiculos {@CategoriaDeVeiculos} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Categoria de veiculos {CategoriaDeVeiculosNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(CategoriaDeVeiculos arg)
        {
            logger.Information("Tentando editar Categoria de veiculos... {@CategoriaDeVeiculos}", arg);
            var resultadoValidacao = ValidarCategoriaDeVeiculos(arg);

            if (resultadoValidacao.IsValid) 
            { 
                repositorioCategoriaDeVeiculos.Editar(arg);
                logger.Information("Categoria de veiculos {@CategoriaDeVeiculos} editado com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Categoria de veiculos {CategoriaDeVeiculosNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCategoriaDeVeiculos(CategoriaDeVeiculos arg)
        {
            ValidadorCategoriaDeVeiculos validador = new ValidadorCategoriaDeVeiculos();

            var resultadoValidacao = validador.Validate(arg);

            if (NomeDuplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
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
