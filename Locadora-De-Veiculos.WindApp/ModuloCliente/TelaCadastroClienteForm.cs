using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
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

namespace Locadora_De_Veiculos.WindApp.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {
        private Cliente cliente;
        public TelaCadastroClienteForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public Cliente Cliente 
        { 
            get => cliente;
            set
            {
                cliente = value;

                txtMask_Cpf_Cnpj.Text = cliente.CPF_CNPJ;
                txt_Email.Text = cliente.Email;
                txtMask_Fone.Text = cliente.Telefone;
                txt_Nome.Text = cliente.Nome;
                txtMask_Cnh.Text = cliente.CNH;
                //dateTime_Validade_Cnh.Value = cliente.Validade_CNH;

                if (Cliente.Validade_CNH > DateTimePicker.MinimumDateTime)
                {
                    dateTime_Validade_Cnh.Value = cliente.Validade_CNH;
                }
                else
                    dateTime_Validade_Cnh.Value = DateTime.Now;

                /*if(Cliente.Validade_CNH > DateTimePicker.MinimumDateTime)
                {
                    dateTime_Validade_Cnh.Value = cliente.Validade_CNH;
                }else
                    dateTime_Validade_Cnh.Value = DateTimePicker.MinimumDateTime;*/

            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (rb_F.Checked)
            {
                cliente.Tipo_Cliente = "Pessoa Física";
            }
            else
            {
                cliente.Tipo_Cliente = "Pessoa Júridica";
            }

            cliente.CPF_CNPJ = txtMask_Cpf_Cnpj.Text;
            cliente.Email = txt_Email.Text;
            cliente.Telefone = txtMask_Fone.Text;
            cliente.Nome = txt_Nome.Text;
            cliente.CNH = txtMask_Cnh.Text;
            cliente.Validade_CNH = DateTime.Parse(dateTime_Validade_Cnh.Text);

            var resultadoValidacao = GravarRegistro(Cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
