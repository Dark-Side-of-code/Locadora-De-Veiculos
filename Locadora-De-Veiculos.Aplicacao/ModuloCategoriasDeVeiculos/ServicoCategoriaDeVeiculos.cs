using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
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

        public ValidationResult Inserir(CategoriaDeVeiculos arg)
        {
            var resultadoValidacao = ValidarCategoriaDeVeiculos(arg);

            if (resultadoValidacao.IsValid)
                repositorioCategoriaDeVeiculos.Inserir(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(CategoriaDeVeiculos arg)
        {
            var resultadoValidacao = ValidarCategoriaDeVeiculos(arg);

            if (resultadoValidacao.IsValid)
                repositorioCategoriaDeVeiculos.Editar(arg);

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

        private bool NomeDuplicado(CategoriaDeVeiculos categoriaDeVeiculos)
        {
            var categoriaDeVeiculosEncontrado = repositorioCategoriaDeVeiculos.SelecionarClientePorNome(categoriaDeVeiculos.Nome);

            return categoriaDeVeiculosEncontrado != null &&
                   categoriaDeVeiculosEncontrado.Nome == categoriaDeVeiculos.Nome &&
                   categoriaDeVeiculosEncontrado.Id != categoriaDeVeiculos.Id;
        }
    }
}
