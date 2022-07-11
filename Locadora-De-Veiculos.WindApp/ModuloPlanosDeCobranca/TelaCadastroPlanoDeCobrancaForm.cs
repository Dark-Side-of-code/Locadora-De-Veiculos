using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca
{
    public partial class TelaCadastroPlanoDeCobrancaForm : Form
    {
        private PlanoDeCobranca plano;
        private List<CategoriaDeVeiculos> categoria;

        public TelaCadastroPlanoDeCobrancaForm(List<CategoriaDeVeiculos> categoria)
        {
            this.categoria = categoria;
            InitializeComponent();
            this.ConfigurarTela();
            CarregarCategoriaDeVeiculos(categoria);
            Inicializar_MascaraDeMoeda_TextBox();
        }

        public Func<PlanoDeCobranca, ValidationResult> GravarRegistro { get;  set; }

        public PlanoDeCobranca Plano
        {
            get => plano;

            set
            {
                plano = value;

                if (plano.CategoriaDeVeiculos != null)
                {
                    cbx_CategoriaVeiculo.SelectedItem = plano.CategoriaDeVeiculos.Nome;
                    cbx_CategoriaVeiculo.SelectedIndex = 0;
                }
                else
                {
                    cbx_CategoriaVeiculo.SelectedIndex = 0;
                }

                //PD = PLANO DIARIO | PC = PLANO CONTROLADO | PL = PLANO LIVRE

                // PLANO DIARIO
                txt_ValorDiario_PD.Text = plano.PlanoDiario_ValorDiario.ToString();
                txt_ValorPorKm_PD.Text = plano.PlanoDiario_ValorPorKM.ToString();

                //PLANO KM LIVRE
                txt_ValorDiario_PL.Text = plano.PlanoKM_Livre_ValorDiario.ToString();

                //PLANO CONTROLADO
                txt_LimiteQuilometragem_PC.Text = plano.PlanoKM_controlado_LimiteDeQuilometragem.ToString();
                txt_PlanoDiario_PC.Text = plano.PlanoKM_controlado_ValorDiario.ToString();
                txt_PlanoPorKm_PC.Text = plano.PlanoKM_controlado_ValorPorKM.ToString();
            }
        }
        private void Inicializar_MascaraDeMoeda_TextBox()
        {
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_ValorPorKm_PD);
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_ValorDiario_PD);
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_PlanoPorKm_PC);
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_PlanoDiario_PC);
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_LimiteQuilometragem_PC);
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_ValorDiario_PL);
        }
        private void CarregarCategoriaDeVeiculos(List<CategoriaDeVeiculos> categoria)
        {
            cbx_CategoriaVeiculo.Items.Clear();

            foreach(var item in categoria)
            {
                cbx_CategoriaVeiculo.Items.Add(item);
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            plano.CategoriaDeVeiculos = (CategoriaDeVeiculos)cbx_CategoriaVeiculo.SelectedItem;

            plano.PlanoDiario_ValorDiario = Convert.ToDouble(txt_ValorDiario_PD.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            plano.PlanoDiario_ValorPorKM = Convert.ToDouble(txt_ValorPorKm_PD.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            plano.PlanoKM_Livre_ValorDiario = Convert.ToDouble(txt_ValorDiario_PL.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            plano.PlanoKM_controlado_LimiteDeQuilometragem = Convert.ToDouble(txt_LimiteQuilometragem_PC.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            plano.PlanoKM_controlado_ValorDiario = Convert.ToDouble(txt_PlanoDiario_PC.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            plano.PlanoKM_controlado_ValorPorKM = Convert.ToDouble(txt_PlanoPorKm_PC.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

            var resultadoValidacao = GravarRegistro(Plano);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
