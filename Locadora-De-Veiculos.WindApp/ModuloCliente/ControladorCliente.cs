using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloCliente
{
    internal class ControladorCliente : ControladorBase
    {
        private RepositorioClienteEmBancoDados repositorioCliente;
        private TabelaClientesControl tabelaCliente;

        public ControladorCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroClienteForm();

            tela.Cliente = new Cliente();

            tela.GravarRegistro = repositorioCliente.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }
        }

        public override void Editar()
        {
            var numero = tabelaCliente.ObtemIdClienteSelecionado();

            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(numero);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Edição de cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroClienteForm();

            tela.Cliente = clienteSelecionado;

            tela.GravarRegistro = repositorioCliente.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarClientes();
            }

        }

        public override void Excluir()
        {
            var numero = tabelaCliente.ObtemIdClienteSelecionado();

            Cliente clienteSelecionado = repositorioCliente.SelecionarPorId(numero);

            if (clienteSelecionado == null)
            {
                MessageBox.Show("Selecione um cliente primeiro",
                "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o cliente?",
               "Exclusão de Clientes", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCliente.Excluir(clienteSelecionado);
                CarregarClientes();
            }
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCliente();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCliente == null)
                tabelaCliente = new TabelaClientesControl();

            CarregarClientes();

            return tabelaCliente;
        }

        private void CarregarClientes()
        {
            List<Cliente> clientes = repositorioCliente.SelecionarTodos();

            tabelaCliente.AtualizarRegistros(clientes);

            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
        }
    }
}
