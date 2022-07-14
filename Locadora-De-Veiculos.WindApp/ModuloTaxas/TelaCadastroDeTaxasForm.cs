using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloTaxas
{
    public partial class TelaCadastroDeTaxasForm : Form
    {

        private Taxa taxa;

        public TelaCadastroDeTaxasForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
            ClassMaskValorNumerico.AplicaMascaraMoeda(txt_Valor);
        }

        public Func<Taxa, Result<Taxa>> GravarRegistro { get; set; }
        
        public Taxa Taxa
        {
            get => taxa;
        
            set
            {
                taxa = value;
        
                txt_Nome.Text = taxa.Nome;
                txt_Valor.Text = taxa.Valor.ToString();
                txt_Descricao.Text = taxa.Descricao;
        
            }
        }
        
        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            taxa.Nome = txt_Nome.Text;
            taxa.Valor = Convert.ToDouble(txt_Valor.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            taxa.Descricao = txt_Descricao.Text;
            if (rb_Fixo.Checked)
                taxa.TipoDeCobraca = "Fixa";
            else
                taxa.TipoDeCobraca = "Diária";
        
            var resultadoValidacao = GravarRegistro(Taxa);
        
            if (resultadoValidacao.IsFailed == false)
            {
                string erro = resultadoValidacao.Errors[0].Message;
        
                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
