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
        private IRepositorioCliente repositorioCliente;

        public ServicoCliente(IRepositorioCliente repositorioCliente)
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

        private bool NomeDuplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorNome(cliente.Nome);

            return clienteEncontrado != null &&
                   clienteEncontrado.Nome == cliente.Nome &&
                   clienteEncontrado.Id != cliente.Id;
        }

        private bool CPF_CNPJ_Duplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCPF_CNPJ(cliente.CPF_CNPJ);

            return clienteEncontrado != null &&
                   clienteEncontrado.CPF_CNPJ == cliente.CPF_CNPJ &&
                   clienteEncontrado.Id != cliente.Id;
        }

        private bool CNH_Duplicado(Cliente cliente)
        {
            var clienteEncontrado = repositorioCliente.SelecionarClientePorCNH(cliente.CNH);

            return clienteEncontrado != null &&
                   clienteEncontrado.CNH == cliente.CNH &&
                   clienteEncontrado.Id != cliente.Id;
        }
    }
}
