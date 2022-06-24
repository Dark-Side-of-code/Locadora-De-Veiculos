using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
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
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }

        public Cliente Cliente 
        { 
            get => cliente;
            set
            {
                cliente = value;

                groupBoxTipoCliente.Text = cliente.Tipo_Cliente;
                txtMask_Cpf_Cnpj.Text = cliente.CPF_CNPJ;
                txt_Email.Text = cliente.Email;
                txtMask_Fone.Text = cliente.Telefone;
                txt_Nome.Text = cliente.Nome;
                txtMask_Cnh.Text = cliente.CNH;
                dateTime_Validade_Cnh.Text = cliente.Validade_CNH.ToString(); 
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            cliente.Tipo_Cliente = groupBoxTipoCliente.Text;
            cliente.CPF_CNPJ = txtMask_Cpf_Cnpj.Text;
            cliente.Email = txt_Email.Text;
            cliente.Telefone = txtMask_Fone.Text;
            cliente.Nome = txt_Nome.Text;
            cliente.CNH = txtMask_Cnh.Text;
            cliente.Validade_CNH = Convert.ToDateTime(dateTime_Validade_Cnh);

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
