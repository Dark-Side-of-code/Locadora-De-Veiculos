using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloMotorista
{
    public partial class TelaCadastroCondutorForm : Form
    {
        private Condutor condutor;
        
        public TelaCadastroCondutorForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get => condutor;
            set
            {
                condutor = value;

                txt_CPF.Text = condutor.CPF;
                txt_Email.Text = condutor.Email;
                txtMask_Fone.Text = condutor.Telefone;
                txt_nome.Text = condutor.Nome;
                txtMask_Cnh.Text = condutor.CNH;
                
                if (Condutor.Validade_CNH > DateTimePicker.MinimumDateTime)
                {
                    dateTime_Validade_Cnh.Value = condutor.Validade_CNH;
                }
                else
                    dateTime_Validade_Cnh.Value = DateTime.Now;
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            condutor.CPF = txt_CPF.Text;
            condutor.Email = txt_Email.Text;
            condutor.Telefone = txtMask_Fone.Text;
            condutor.Nome = txt_nome.Text;
            condutor.CNH = txtMask_Cnh.Text;
            condutor.Validade_CNH = DateTime.Parse(dateTime_Validade_Cnh.Text);

            var resultadoValidacao = GravarRegistro(Condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
        
    }
}
