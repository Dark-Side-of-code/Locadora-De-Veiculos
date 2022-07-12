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
        private ILogger logger = Log.Logger;

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa arg)
        {
            logger.Information("Tentando inserir Taxa... {@taxa}", arg);
            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Inserir(arg);
                logger.Information("Taxa {@taxa} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Taxa {@Taxa} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa arg)
        {
            logger.Information("Tentando editar Taxa... {@taxa}", arg);
            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioTaxa.Editar(arg);
                logger.Information("Taxa {@taxa} editado com sucesso.", arg.Id);
            }   
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Taxa {@Taxa} -> Motivo: {erro}", arg.Id, erro.ErrorMessage);
            return resultadoValidacao;
        }

        private ValidationResult ValidarTaxa(Taxa arg)
        {
            ValidadorTaxa validador = new ValidadorTaxa();

            var resultadoValidacao = validador.Validate(arg);

            if (NomeDuplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("Nome", "Nome duplicado"));

            return resultadoValidacao;
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
