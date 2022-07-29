using Locadora_De_Veiculos.Aplicacao.ModuloDevolucao;
using Locadora_De_Veiculos.Aplicacao.ModuloLocacao;
using Locadora_De_Veiculos.Dominio.ModuloDevolucao;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public class ControladorDeDevolucoes : ControladorBase
    {
        private TabelaDevolucaoControl? listagemDevolucao;
        private readonly ServicoDevolucao servicoDevolucao;
        private readonly ServicoLocacao servicoLocacao;


        List<Locacao> locacoes = new List<Locacao>();

        public ControladorDeDevolucoes(ServicoDevolucao servicoDevolucao, ServicoLocacao servicoLocacao)
        {
            this.servicoDevolucao = servicoDevolucao;
            this.servicoLocacao = servicoLocacao;
        }

        public override void Inserir()
        {
            var resultadoLocacao = servicoLocacao.SelecionarTodos();
            if (resultadoLocacao.IsSuccess)
                locacoes = resultadoLocacao.Value;

            if(locacoes.Count == 0)
            {
                MessageBox.Show("Insira uma locação primeiro",
               "Inserção de Devolucao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroDevolucao();

            tela.Devolucao = new Devolucao();

            tela.GravarRegistro = servicoDevolucao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarDevolucao();
            }

        }

        public override void Editar()
        {
        }

        public override void Excluir()
        {
            var id = listagemDevolucao.ObtemIdDevolucaoSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Devolução primeiro",
                    "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoDevolucao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var locacaoSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a Devolução?", "Exclusão de Devolução",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoDevolucao.Excluir(locacaoSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarDevolucao();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Devolução", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            throw new NotImplementedException();
        }

        private void CarregarDevolucao()
        {
            var resultado = servicoDevolucao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Devolucao> devolucoes = resultado.Value;

                listagemDevolucao.AtualizarRegistros(devolucoes);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} devolução(oes)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Devolução",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
