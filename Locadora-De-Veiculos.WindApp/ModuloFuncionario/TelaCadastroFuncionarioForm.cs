using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        public Func<Funcionario, ValidationResult> GravarRegistro { get; set; }

        public Funcionario Funcionario
        {
            get => funcionario;

            set
            {
                funcionario = value;

                txt_Nome.Text = funcionario.Nome;
                txt_Login.Text = funcionario.Login;
                txt_Senha.Text = funcionario.Senha;
                txt_Salario.Text = funcionario.Salario.ToString();

                if (funcionario.DataAdmissao > DateTimePicker.MinimumDateTime)
                {
                    Data_Adimissao.Value = funcionario.DataAdmissao;
                }
                else 
                    Data_Adimissao.Value = DateTimePicker.MinimumDateTime;


            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            funcionario.Nome = txt_Nome.Text;
            funcionario.Login = txt_Login.Text;
            funcionario.Senha = txt_Senha.Text;
            funcionario.Salario = Convert.ToDouble(txt_Salario.Text);
            funcionario.DataAdmissao = Data_Adimissao.Value;
            
            if (rb_Admin.Checked)
                funcionario.TipoFuncionario = true;
            else
                funcionario.TipoFuncionario = false;

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
