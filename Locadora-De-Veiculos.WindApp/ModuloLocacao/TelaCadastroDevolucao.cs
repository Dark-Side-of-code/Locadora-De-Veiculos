using FluentResults;
using Locadora_De_Veiculos.Dominio.ModuloDevolucao;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.Compartilhado.Funções;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucao : Form
    {
        private Locacao locacao2;
        private Locacao locacao;
        public List<Taxa> taxas;
   

        public TelaCadastroDevolucao( List<Taxa> taxas, Locacao locacao)
        {
            InitializeComponent();
            this.ConfigurarTela();
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_ValorGasolina);
            this.taxas = taxas;
            locacao2 = locacao;
            if (locacao2 != null)
            {
                CarregarTaxasJaInseridas();
                CarregarTaxasExtras();
            }
            CarregarNivelTanque();

        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }


        public Locacao Locacao
        {
            get => locacao;

            set
            {
                locacao = value;

                lb_Funcionario.Text = locacao.Funcionario.Nome;
                lb_Cliente.Text = locacao.Cliente.Nome;
                lb_Condutor.Text = locacao.Condutor.Nome;
                lb_Categoria.Text = locacao.Categoria.Nome;
                lb_Veiculo.Text = locacao.Veiculo.Modelo;
                lb_DataLocacao.Text = locacao.DataInicio.ToString("dd/MM/yyyy");
                lb_DevoluçãoPrevista.Text = locacao.DataFinalPrevista.ToString("dd/MM/yyyy");
                lb_PlanoCobranca.Text = locacao.NomeDoPlano;
                txt_QuilometragemVeiculo.Text = locacao.QuilometragemDoVeiculo.ToString();

                if (locacao.NivelDoTanque != null)
                {
                    cbx_NivelTanque.SelectedItem = locacao.NivelDoTanque;
                    cbx_NivelTanque.SelectedIndex = 0;
                }
                else
                {
                    cbx_NivelTanque.SelectedIndex = 0;
                }
                
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            AtribuirValoresNivelTanque();
            locacao.Funcionario.Nome = lb_Funcionario.Text;
            locacao.Cliente.Nome = lb_Cliente.Text;
            locacao.Condutor.Nome = lb_Condutor.Text;
            locacao.Categoria.Nome = lb_Categoria.Text;
            locacao.Veiculo.Modelo = lb_Veiculo.Text;
            locacao.Veiculo.StatusVeiculo = true;
            locacao.DataInicio = DateTime.Parse(lb_DataLocacao.Text);
            locacao.DataFinalPrevista = DateTime.Parse(lb_DevoluçãoPrevista.Text);
            locacao.NomeDoPlano = lb_PlanoCobranca.Text;
            locacao.DataFinalReal = DateTime.Parse(dateTimePicker_DataDevolucao.Text);

            locacao.QuilometragemDoVeiculo = Convert.ToDouble(txt_QuilometragemVeiculo.Text);
            
            //locacao.NivelDoTanque = Convert.ToDecimal(cbx_NivelTanque.Text);
            locacao.ValorGasolina = Convert.ToDouble(txt_ValorGasolina.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)); 

            //locacao.Taxas = Convert.ToString(List_taxasSelecionadas.);

            //locacao.TaxaAdicional = Convert.ToString(List_TaxaAdicionais.Text);
            // locacao.ValorTotal = Convert.ToDouble(lb_ValorTotal.Text);

            var resultadoValidacao = GravarRegistro(Locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        #region Métodos Privados

        private void CarregarTaxasJaInseridas()
        {
            List_taxasSelecionadas.Items.Clear();

            foreach (Taxa t in locacao2.Taxas)
            {
                List_taxasSelecionadas.Items.Add(t);
            }
        }

        private void CarregarTaxasExtras()
        {
            foreach (var taxa in taxas)
            {
                if (!locacao.Taxas.Contains(taxa))
                {
                    if (taxa.TipoDeCobraca == "Fixa")
                        List_TaxaAdicionais.Items.Add(taxa);
                }
            }
        }

        private double AtribuirValoresNivelTanque()
        {
            double resultado = 0;

            if (cbx_NivelTanque.SelectedItem == "0%")
            {
                resultado = 0;
            }
            else if (cbx_NivelTanque.SelectedItem == "25%")
            {
                resultado = 0.25;
            }
            else if (cbx_NivelTanque.SelectedItem == "50%")
            {
                resultado = 0.50;
            }
            else if (cbx_NivelTanque.SelectedItem == "75")
            {
                resultado = 0.75;
            }
            else
                resultado = 1;

            return resultado;
        }

        private void CarregarNivelTanque()
        {
            cbx_NivelTanque.Items.Add("0%");
            cbx_NivelTanque.Items.Add("25%");
            cbx_NivelTanque.Items.Add("50%");
            cbx_NivelTanque.Items.Add("75%");
            cbx_NivelTanque.Items.Add("100%");
        }
        #endregion
    }
}
