using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
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
        public List<Cliente> clientes;

        public TelaCadastroCondutorForm(List<Cliente> clientes)
        {
            this.clientes = clientes;
            InitializeComponent();
            this.ConfigurarTela();
            PreencherComboBox();
        }

        public Func<Condutor, ValidationResult> GravarRegistro { get; set; }

        public Condutor Condutor
        {
            get => condutor;
            set
            {
                condutor = value;

                if(condutor.Cliente != null)
                {
                    cbx_cliente.SelectedItem = condutor.Cliente;
                    cbx_cliente.SelectedIndex = 0;
                }
                else
                {
                    cbx_cliente.SelectedIndex = 0;
                }

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
            condutor.Cliente = (Cliente)cbx_cliente.SelectedItem;
            condutor.CPF = txt_CPF.Text;
            condutor.Email = txt_Email.Text;
            condutor.Telefone = txtMask_Fone.Text;
            condutor.Nome = txt_nome.Text;
            condutor.CNH = txtMask_Cnh.Text;
            condutor.Edereco = txt_endereco.Text;
            condutor.Validade_CNH = DateTime.Parse(dateTime_Validade_Cnh.Text);

            var resultadoValidacao = GravarRegistro(Condutor);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
        
        public void PreencherComboBox()
        {
            cbx_cliente.Items.Clear();

            foreach(Cliente c in clientes)
            {
                cbx_cliente.Items.Add(c);
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if(condutor.Cliente != null)
            {
                if (checkBox1.Checked == true)
                {
                    condutor.Cliente = (Cliente)cbx_cliente.SelectedItem;
                    txt_CPF.Text = condutor.Cliente.CPF_CNPJ;
                    txt_Email.Text = condutor.Cliente.Email;
                    txtMask_Fone.Text = condutor.Cliente.Telefone;
                    txt_nome.Text = condutor.Cliente.Nome;
                }
                else
                {
                    condutor.Cliente = (Cliente)cbx_cliente.SelectedItem;
                    txt_CPF.Text = "";
                    txt_Email.Text = "";
                    txtMask_Fone.Text = "";
                    txt_nome.Text = "";
                }
            }
        }
    }
}
