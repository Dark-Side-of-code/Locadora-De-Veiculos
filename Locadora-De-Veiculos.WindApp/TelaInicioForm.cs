using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.WindApp.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp
{
    public partial class TelaInicioForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;
        public TelaInicioForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;

            labelTipoCadastro.Text = string.Empty;

            InicializarControladores();
        }
        public static TelaInicioForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void TaxasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }

        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            RepositorioTaxaEmBancoDados repositorioTaxa = new RepositorioTaxaEmBancoDados();
            //RepositorioFuncionarioEmBancoDados repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            //RepositorioClienteEmBancoDados repositorioCliente = new RepositorioClienteEmBancoDados();
            RepositorioCategoriaDeVeiculosEmBancoDados repositorioCategoria = new RepositorioCategoriaDeVeiculosEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Taxas", new ControladorTaxa(repositorioTaxa));
            //controladores.Add("Funcionários", new ControladorDeFuncionario(repositorioFuncionario));
            //controladores.Add("Clientes", new ControladorCliente(repositorioCliente));
            controladores.Add("Catergorias", new ControladorDeCategoriaDeVeiculo(repositorioCategoria));
        }

        private void ClientesMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void FuncionarioMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void CatergoriasMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }
    }
}
