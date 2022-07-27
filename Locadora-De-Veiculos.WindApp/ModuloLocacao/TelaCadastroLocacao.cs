using FluentResults;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public partial class TelaCadastroLocacao : Form
    {
        private Locacao locacao;

        public TelaCadastroLocacao()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }

        public Locacao Locacao
        {
            get => locacao;

            set
            {
                locacao = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resultadoValidacao = GravarRegistro(Locacao);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }
    }
}
