using FluentResults;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.Compartilhado.Funções;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public partial class TelaCadastroLocacaoForm : Form
    {
        private Locacao locacao;
        public List<Funcionario> funcionarios;
        public List<Cliente> clientes; 
        public List<Condutor> condutores;
        public List<CategoriaDeVeiculos> categorias;
        public List<Veiculo> veiculos;
        public List<PlanoDeCobranca> planos;
        public List<Taxa> taxas;

        public TelaCadastroLocacaoForm(List<Funcionario> funcionario, List<Cliente> clientes, List<Condutor> condutor, List<CategoriaDeVeiculos> categoria, List<Veiculo> veiculo, List<PlanoDeCobranca> plano, List<Taxa> taxa)
        {
            InitializeComponent();
            this.ConfigurarTela();
            this.funcionarios = funcionario;
            this.clientes = clientes;
            this.condutores = condutor;
            this.categorias = categoria;
            this.veiculos = veiculo;
            this.planos = plano;
            this.taxas = taxa;
            PreencherComboBox();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get => locacao;

            set
            {
                locacao = value;

                if (locacao.Funcionario != null)
                {
                    cbxFuncionario.SelectedItem = locacao.Funcionario;
                    cbxFuncionario.SelectedIndex = 0;
                }
                else
                {
                    cbxFuncionario.SelectedIndex = 0;
                }

                if (locacao.Cliente != null)
                {
                    cbxCliente.SelectedItem = locacao.Cliente;
                    cbxCliente.SelectedIndex = 0;
                }
                else
                {
                    cbxCliente.SelectedIndex = 0;
                }

                if (locacao.Condutor != null)
                {
                    cbxCondutor.SelectedItem = locacao.Condutor;
                    cbxCondutor.SelectedIndex = 0;
                }
                else
                {
                    if(cbxCondutor.Items.Count > 0)
                        cbxCondutor.SelectedIndex = 0;
                }

                if (locacao.Categoria != null)
                {
                    cbxCategoria.SelectedItem = locacao.Categoria;
                    cbxCategoria.SelectedIndex = 0;
                }
                else
                {
                    cbxCategoria.SelectedIndex = 0;
                }

                if (locacao.Veiculo != null)
                {
                    cbxVeiculo.SelectedItem = locacao.Veiculo;
                    cbxVeiculo.SelectedIndex = 0;
                }
                else
                {
                    if(cbxVeiculo.Items.Count > 0)
                        cbxVeiculo.SelectedIndex = 0;
                }

                if (locacao.PlanoDeCobranca != null)
                {
                    cbxPlano.SelectedItem = locacao.PlanoDeCobranca;
                    cbxPlano.SelectedIndex = 0;
                }
                else
                {
                    cbxPlano.SelectedIndex = 0;
                }


                if (locacao.DataInicio > DateTimePicker.MinimumDateTime)
                    dateInicio.Value = locacao.DataInicio;
                else
                    dateInicio.Value = DateTime.Today;

                if (locacao.DataFinalPrevista >DateTimePicker.MinimumDateTime)
                    dateDevolucao.Value = locacao.DataFinalPrevista;
                else
                    dateDevolucao.Value = DateTime.Today;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            locacao.Funcionario = (Funcionario)cbxFuncionario.SelectedItem;
            locacao.Cliente = (Cliente)cbxCliente.SelectedItem;
            locacao.Condutor = (Condutor)cbxCondutor.SelectedItem;
            locacao.Categoria = (CategoriaDeVeiculos)cbxCategoria.SelectedItem;
            locacao.Veiculo = (Veiculo)cbxVeiculo.SelectedItem;
            Veiculo veiculo = (Veiculo)cbxVeiculo.SelectedItem;
            PlanoDeCobranca plano = null;
            foreach(PlanoDeCobranca p in planos)
            {
                if (p.CategoriaDeVeiculos == (CategoriaDeVeiculos)cbxCategoria.SelectedItem)
                    plano = p;
            }
            locacao.PlanoDeCobranca = plano;
            locacao.NomeDoPlano = cbxPlano.Text;
            locacao.valorEstimado = CalcularValorFinal();
            locacao.DataInicio = DateTime.Parse(dateInicio.Text);
            locacao.DataFinalPrevista = DateTime.Parse(dateDevolucao.Text);
            locacao.Status = "Em Aberto";
            locacao.TipoDoPlano = cbxPlano.Text;
            List<Taxa> taxasSelecionadas = new List<Taxa>();
            foreach (Taxa t in listTaxas.CheckedItems)
            {
                taxasSelecionadas.Add(t);
            }
            locacao.Taxas = taxasSelecionadas;

            locacao.DataFinalReal = DateTime.MaxValue;
            var resultadoValidacao = GravarRegistro(Locacao);


            if (!resultadoValidacao.IsFailed)
            {
                locacao.AlterarStatusDoVeiculo();
            }

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        public void PreencherComboBox()
        {
            CarregarFuncionarios();
            CarregarClientes();
            CarregarCondutores();
            CarregarCategorias();
            CarregarVeiculos();
            CarregarPlanos();
            CarregarTaxas();
        }

        private void ClienteChanged(object sender, EventArgs e)
        {
            CarregarCondutores();
        }

        private void CategoriaChanged(object sender, EventArgs e)
        {
            CarregarVeiculos();
            CalcularValorFinal();
        }

        private void VeiculoChanged(object sender, EventArgs e)
        {
            var veiculo = (Veiculo)cbxVeiculo.SelectedItem;
            txtKm.Text = veiculo.Km_total.ToString() + " Km";
        }

        private void PlanoChanged(object sender, EventArgs e)
        {
            if (cbxPlano.SelectedItem != null)
                ValorFinal.Text = CalcularValorFinal().ToString();
        }

        private void DataFinalChanged(object sender, EventArgs e)
        {
            CalcularValorFinal();
        }

        private void DataInicialChanged(object sender, EventArgs e)
        {
            CalcularValorFinal();
        }

        private void taxasChenged(object sender, EventArgs e)
        {
            CalcularValorFinal();
        }

        #region Metodos Privados

        private void CarregarPlanos()
        {
            cbxPlano.Items.Add("Diario");
            cbxPlano.Items.Add("Km Controlado");
            cbxPlano.Items.Add("Km Livre");
        }

        private void CarregarVeiculos()
        {
            cbxVeiculo.Items.Clear();
            cbxVeiculo.Text = "";

            foreach (Veiculo c in veiculos)
            {
                if(c.CategoriaDeVeiculos == (CategoriaDeVeiculos)cbxCategoria.SelectedItem && c.StatusVeiculo == true)
                cbxVeiculo.Items.Add(c);
            }
            if (cbxVeiculo.Items.Count > 0)
                cbxVeiculo.SelectedIndex = 0;

        }

        private void CarregarCategorias()
        {
            cbxCategoria.Items.Clear();

            foreach (CategoriaDeVeiculos c in categorias)
            {
                cbxCategoria.Items.Add(c);
            }
        }

        private void CarregarCondutores()
        {
            cbxCondutor.Items.Clear();
            cbxCondutor.Text = "";

            foreach (Condutor c in condutores)
            {
                if (c.Cliente == (Cliente)cbxCliente.SelectedItem)
                    cbxCondutor.Items.Add(c);
            }
            if (cbxVeiculo.Items.Count > 0)
                cbxVeiculo.SelectedIndex = 0;
        }

        private void CarregarClientes()
        {
            cbxCliente.Items.Clear();

            foreach (Cliente c in clientes)
            {
                cbxCliente.Items.Add(c);
            }
        }

        private void CarregarFuncionarios()
        {
            cbxFuncionario.Items.Clear();

            foreach (Funcionario f in funcionarios)
            {
                cbxFuncionario.Items.Add(f);
            }
        }

        private void CarregarTaxas()
        {
            listTaxas.Items.Clear();

            foreach (Taxa t in taxas)
            {
                listTaxas.Items.Add(t);
            }
        }

        private double CalcularValorFinal()
        {
            PlanoDeCobranca pCalculo = null;
            double resultado = 0;

            int dias = (dateDevolucao.Value - dateInicio.Value).Days + 1;

            foreach (PlanoDeCobranca p in planos)
            {
                if (p.CategoriaDeVeiculos == (CategoriaDeVeiculos)cbxCategoria.SelectedItem)
                    pCalculo = p;
            }

            resultado = CalcularValorDasTaxas();

            if (cbxPlano.Text == "Diario")
            {
                resultado = resultado + (dias * pCalculo.PlanoDiario_ValorDiario);
            }
            if (cbxPlano.Text == "Km Controlado")
            {
                resultado = resultado + (dias * pCalculo.PlanoKM_controlado_ValorDiario);
            }
            if (cbxPlano.Text == "Km Livre")
            {
                resultado = resultado + (dias * pCalculo.PlanoKM_Livre_ValorDiario);
            }
            ValorFinal.Text = resultado.ToString();
            return resultado;
        }

        private double CalcularValorDasTaxas()
        {
            double valortaxastot = 0;

            int dias = (dateDevolucao.Value - dateInicio.Value).Days + 1;

            foreach (Taxa t in listTaxas.CheckedItems)
            {
                if(t.TipoDeCobraca == "Fixa")
                {
                    valortaxastot = valortaxastot + t.Valor;
                }
                else
                {
                    valortaxastot = valortaxastot + (t.Valor * dias);
                }
            }
            return valortaxastot;
        }

        #endregion

        private void listTaxas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach(var t in listTaxas.CheckedItems)
            //{
            //    if()
            //}
            CalcularValorFinal();
        }
    }
}
