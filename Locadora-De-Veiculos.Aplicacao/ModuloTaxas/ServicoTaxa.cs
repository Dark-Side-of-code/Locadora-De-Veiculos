using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
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

        public ServicoTaxa(IRepositorioTaxa repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public ValidationResult Inserir(Taxa arg)
        {
            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Taxa arg)
        {
            var resultadoValidacao = ValidarTaxa(arg);

            if (resultadoValidacao.IsValid)
                repositorioTaxa.Editar(arg);

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

        private bool NomeDuplicado(Taxa taxa)
        {
            var taxaEncontrada = repositorioTaxa.SelecionarTaxaPorNome(taxa.Nome);

            return taxaEncontrada != null &&
                   taxaEncontrada.Nome == taxa.Nome &&
                   taxaEncontrada.Id != taxa.Id;
        }
    }
}
