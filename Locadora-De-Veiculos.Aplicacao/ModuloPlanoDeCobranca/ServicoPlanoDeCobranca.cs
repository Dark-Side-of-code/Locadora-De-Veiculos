using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
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

        public ValidationResult Inserir(PlanoDeCobranca planoDeCobranca)
        {
            ValidationResult resultadoValidacao = ValidarPlanoDeCobranca(planoDeCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Inserir(planoDeCobranca);
            
            return resultadoValidacao;
        }


        public ValidationResult Editar(PlanoDeCobranca planoDeCobranca)
        {
            ValidationResult resultadoValidacao = ValidarPlanoDeCobranca(planoDeCobranca);

            if (resultadoValidacao.IsValid)
                repositorioPlanoDeCobranca.Editar(planoDeCobranca);

            return resultadoValidacao;
        }

        private ValidationResult ValidarPlanoDeCobranca(PlanoDeCobranca planoDeCobranca)
        {
            var validador = new ValidadorPlanoDeCobranca();

            var resultadoValidacao = validador.Validate(planoDeCobranca);

            if (IdCategoriaDuplicado(planoDeCobranca))
                resultadoValidacao.Errors.Add(new ValidationFailure("Categoria", "Categoria duplicada"));

            
            return resultadoValidacao;
        }

        private bool IdCategoriaDuplicado(PlanoDeCobranca planoDeCobranca)
        {
            var planoEncontrado = repositorioPlanoDeCobranca.SelecionarIdCategoria(planoDeCobranca.CategoriaDeVeiculos.Id);

            return planoEncontrado != null && 
                   planoEncontrado.CategoriaDeVeiculos.Id == planoDeCobranca.CategoriaDeVeiculos.Id &&
                   planoDeCobranca.Id != planoDeCobranca.Id;
        }
    }
}
