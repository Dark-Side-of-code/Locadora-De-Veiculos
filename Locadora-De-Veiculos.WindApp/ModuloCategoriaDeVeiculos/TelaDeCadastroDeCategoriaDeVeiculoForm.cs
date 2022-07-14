using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using FluentValidation.Results;
using System;
using System.Windows.Forms;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using FluentResults;

namespace Locadora_De_Veiculos.WindApp.ModuloGrupoDeVeiculos
{
    public partial class TelaDeCadastroDeCategoriaDeVeiculoForm : Form
    {
        private CategoriaDeVeiculos categoriaDeVeiculos;

        public TelaDeCadastroDeCategoriaDeVeiculoForm()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<CategoriaDeVeiculos, Result<CategoriaDeVeiculos>> GravarRegistro { get; set; }

        public CategoriaDeVeiculos CategoriaDeVeiculos
        {
            get => categoriaDeVeiculos;

            set
            {
                categoriaDeVeiculos = value;

                txt_Nome.Text = categoriaDeVeiculos.Nome;

            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            categoriaDeVeiculos.Nome = txt_Nome.Text;

            var resultadoValidacao = GravarRegistro(CategoriaDeVeiculos);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
