using FluentValidation.Results;
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
        private ILogger logger = Log.Logger;

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor arg)
        {
            logger.Information("Tentando inserir Condutor... {@Condutor}", arg);
            var resultadoValidacao = ValidarCondutor(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Inserir(arg);
                logger.Information("Condutor {@Condutor} inserido com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar inserir Condutor {CondutorNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor arg)
        {
            logger.Information("Tentando editar Condutor... {@Condutor}", arg);
            var resultadoValidacao = ValidarCondutor(arg);

            if (resultadoValidacao.IsValid)
            {
                repositorioCondutor.Editar(arg);
                logger.Information("Condutor {@Condutor} editado com sucesso.", arg.Id);
            }
            else
                foreach (var erro in resultadoValidacao.Errors)
                    logger.Warning("Falha ao tentar editar Condutor {CondutorNome} -> Motivo: {erro}", arg.Nome, erro.ErrorMessage);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCondutor(Condutor arg)
        {
            ValidadorCondutor validador = new ValidadorCondutor();

            var resultadoValidacao = validador.Validate(arg);

            if (CPF_Duplicado(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("CPF", "CPF duplicado"));

            if (CNH_Duplicada(arg))
                resultadoValidacao.Errors.Add(new ValidationFailure("CNH", "CNH duplicada"));

            return resultadoValidacao;
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
