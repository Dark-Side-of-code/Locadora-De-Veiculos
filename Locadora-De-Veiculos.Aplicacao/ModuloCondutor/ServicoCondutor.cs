using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
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

        public ServicoCondutor(IRepositorioCondutor repositorioCondutor)
        {
            this.repositorioCondutor = repositorioCondutor;
        }

        public ValidationResult Inserir(Condutor arg)
        {
            var resultadoValidacao = ValidarCondutor(arg);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Condutor arg)
        {
            var resultadoValidacao = ValidarCondutor(arg);

            if (resultadoValidacao.IsValid)
                repositorioCondutor.Editar(arg);

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
