using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.ModuloCliente;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.WindApp.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Locadora_De_Veiculos.Aplicacao.ModuloFuncionario;
using Locadora_De_Veiculos.Aplicacao.ModuloCliente;
using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.ModuloCondutor;
using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.WindApp.ModuloMotorista;
using Locadora_De_Veiculos.Infra.Banco.ModuloVeiculo;
using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Infra.Banco.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.WindApp.ModuloTaxa;

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
            var repositorioCliente = new RepositorioClienteEmBancoDados();
            var repositorioGrupoVeiculos = new RepositorioCategoriaDeVeiculosEmBancoDados();
            var repositorioTaxa = new RepositorioTaxaEmBancoDados();
            var repositorioFuncionario = new RepositorioFuncionarioEmBancoDados();
            var repositorioCondutor = new RepositorioCondutorEmBancoDados();
            var repositorioVeiculo = new RepositorioVeiculoEmBancoDados();
            var repositorioPlanoDeCobranca = new RepositorioPlanosDeCobrancaEmBancoDados();

            var servicoFuncionario = new ServicoFuncionario(repositorioFuncionario);
            var servicoCliente = new ServicoCliente(repositorioCliente);
            var servicoCategoriaDeVeiculos = new ServicoCategoriasDeVeiculos(repositorioGrupoVeiculos);
            var servicoTaxa = new ServicoTaxa(repositorioTaxa);
            var servicoCondutor = new ServicoCondutor(repositorioCondutor);
            var servicoVeiculo = new ServicoVeiculo(repositorioVeiculo);
            var servicoPlanoDeCobranca = new ServicoPlanoDeCobranca(repositorioPlanoDeCobranca);

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Taxas", new ControladorTaxa(servicoTaxa));
            controladores.Add("Clientes", new ControladorCliente(servicoCliente));
            controladores.Add("Catergorias", new ControladorDeCategoriaDeVeiculo(servicoCategoriaDeVeiculos));
            controladores.Add("Funcionários",new ControladorDeFuncionario(servicoFuncionario));
            controladores.Add("Condutores", new ControladorCondutor(servicoCondutor));
            controladores.Add("Veiculos", new ControladorVeiculo(repositorioGrupoVeiculos, servicoVeiculo));
            controladores.Add("Planos de Cobrança", new ControladorPlanoDeCobranca(servicoPlanoDeCobranca));
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

        private void CondutoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void planosDeCobrançaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }
    }
}
