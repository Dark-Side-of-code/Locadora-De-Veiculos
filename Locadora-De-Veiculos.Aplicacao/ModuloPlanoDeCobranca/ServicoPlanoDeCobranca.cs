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
        private ILogger logger = Log.Logger;

        public ServicoPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
        }

        public ValidationResult Inserir(PlanoDeCobranca arg)
        {
            logger.Information("Tentando inserir Plano de cobrança... {@PlanoCobranca}", arg);
            ValidationResult resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Inserir(arg);
                logger.Information("Plano de cobrança {@PlanoCobranca} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Plano de cobrança {PlanoCobranca} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);

            return resultadoValidacao;
        }


        public ValidationResult Editar(PlanoDeCobranca arg)
        {
            logger.Information("Tentando editar Plano de cobrança... {@PlanoCobranca}", arg);
            ValidationResult resultadoValidacao = ValidarPlanoDeCobranca(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioPlanoDeCobranca.Editar(arg);
                logger.Information("Plano de cobrança {@PlanoCobranca} editado com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Plano de cobrança {PlanoCobranca} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);

            return resultadoValidacao;
        }

        private ValidationResult ValidarPlanoDeCobranca(PlanoDeCobranca arg)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(arg);

            if (NomeCategoriaDuplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome da Categoria", "Nome da Categoria duplicado"));
            
            return resultadoValidacao;
        }

        private bool NomeCategoriaDuplicado(PlanoDeCobranca arg)
        { 
            var planoEncontrado = repositorioPlanoDeCobranca.SelecionarNomeCategoria(arg.CategoriaDeVeiculos.Nome);

            return planoEncontrado != null &&
                   planoEncontrado.CategoriaDeVeiculos.Nome == arg.CategoriaDeVeiculos.Nome &&
                   planoEncontrado.Id != arg.CategoriaDeVeiculos.Id;
        }
    }
}
