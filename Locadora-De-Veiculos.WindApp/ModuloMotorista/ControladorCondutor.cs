using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloMotorista
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly IRepositorioCondutor repositorioCondutor;
        private readonly IRepositorioCliente repositorioCliente;
        private TabelaCondutorControl? listagemCondutor;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(IRepositorioCondutor repositorioCondutor, IRepositorioCliente repositorioCliente, ServicoCondutor servicoCondutor)
        {
            this.repositorioCliente = repositorioCliente;
            this.repositorioCondutor = repositorioCondutor;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroCondutorForm(this.repositorioCliente.SelecionarTodos());

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutor();
            }
        }

        public override void Editar()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Edição de condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroCondutorForm(this.repositorioCliente.SelecionarTodos());

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutor();
            }
        }

        public override void Excluir()
        {
            Condutor condutorSelecionado = ObtemCondutorSelecionado();

            if (condutorSelecionado == null)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                "Exclusão de Condutors", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o condutor?",
               "Exclusão de Condutors", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioCondutor.Excluir(condutorSelecionado);
                CarregarCondutor();
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }
        private void CarregarCondutor()
        {
            List<Condutor> clientes = repositorioCondutor.SelecionarTodos();
            listagemCondutor?.AtualizarRegistros(clientes);
            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {clientes.Count} cliente(s)");
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCondutor == null)
                listagemCondutor = new TabelaCondutorControl();

            CarregarCondutor();

            return listagemCondutor;
        }

        private Condutor ObtemCondutorSelecionado()
        { 
            var id = listagemCondutor.ObtemIdCondutorSelecionado();

            return repositorioCondutor.SelecionarPorNumero(id);
        }
    }
}

