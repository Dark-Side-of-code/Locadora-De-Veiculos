using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {
        private RepositorioClienteEmBancoDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public ValidationResult Inserir(Cliente arg)
        {
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(arg);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Cliente arg)
        {
            var resultadoValidacao = ValidarCliente(arg);

            if (resultadoValidacao.IsValid)
                repositorioCliente.Editar(arg);

            return resultadoValidacao;
        }

        private ValidationResult ValidarCliente(Cliente arg)
        {
            ValidadorCliente validador = new ValidadorCliente();

            var resultadoValidacao = validador.Validate(arg);

            return resultadoValidacao;
        }
    }
}
