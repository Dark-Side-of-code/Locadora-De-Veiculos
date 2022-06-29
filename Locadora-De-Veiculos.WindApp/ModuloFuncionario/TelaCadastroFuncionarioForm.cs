using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.Compartilhado;
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

namespace Locadora_De_Veiculos.WindApp.ModuloFuncionario
{
    public partial class TelaCadastroFuncionarioForm : Form
    {

        private Funcionario funcionario;

        public TelaCadastroFuncionarioForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
            ClassMaskMoeda.AplicaMascaraMoeda2(txt_Salario);
        }

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get => funcionario;

            set
            {
                funcionario = value;

                if (funcionario.TipoFuncionario != "Funcionario Admin")
                {
                    rb_Comum.Checked = true;
                }
                else
                {
                    rb_Admin.Checked = true;
                }

                txt_Nome.Text = funcionario.Nome;
                txt_Login.Text = funcionario.Login;
                txt_Senha.Text = funcionario.Senha;
                txt_Salario.Text = funcionario.Salario.ToString();

                if (funcionario.DataAdmissao > DateTimePicker.MinimumDateTime)
                {
                    Data_Adimissao.Value = funcionario.DataAdmissao;
                }
                else 
                    Data_Adimissao.Value = DateTime.Now;


            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {

           
                funcionario.Nome = txt_Nome.Text;
                funcionario.Login = txt_Login.Text;
                funcionario.Senha = txt_Senha.Text;
                funcionario.Salario = Convert.ToDouble(txt_Salario.Text.Replace("R$", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                funcionario.DataAdmissao = Data_Adimissao.Value;

                if (rb_Admin.Checked)
                    funcionario.TipoFuncionario = "Funcionario Admin";

                else if(rb_Comum.Checked)
                    funcionario.TipoFuncionario = "Funcionario Comum";
            


            var resultadoValidacao = GravarRegistro(Funcionario);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
            
        }
    }
}
