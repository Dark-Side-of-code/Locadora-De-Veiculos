using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.Compartilhado.Funções;
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
            ClassMaskValorNumerico.AplicaMascaraValorNumerico(txtMask_Cpf_Cnpj);
        }

        public Func<Cliente, Result<Cliente>> GravarRegistro { get; set; }

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

            var resultadoValidacao = GravarRegistro(Cliente);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaInicioForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }
    }
}
