using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloTaxas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloTaxa
{
    public class ControladorTaxa : ControladorBase
    {
        private TabelaTaxasControl? listagemTaxa;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxa( ServicoTaxa servicoTaxa)
        {
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroDeTaxasForm();

            tela.Taxa = new Taxa();

            tela.GravarRegistro = servicoTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxa();
            }
        }
        
        public override void Editar()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoTaxa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var taxaSelecionado = resultado.Value;

            var tela = new TelaCadastroDeTaxasForm();

            tela.Taxa = (Taxa)taxaSelecionado.Clone();

            tela.GravarRegistro = servicoTaxa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarTaxa();
        }

        public override void Excluir()
        {
            var id = listagemTaxa.ObtemIdTaxaSelecionada();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoTaxa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o funcionário?", "Exclusão de Funcionário",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoTaxa.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarTaxa();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxTaxa();
        }
        
        public override UserControl ObtemListagem()
        {
            if (listagemTaxa == null)
                listagemTaxa = new TabelaTaxasControl();
        
            CarregarTaxa();
        
            return listagemTaxa;
        }
        
        private void CarregarTaxa()
        {
            var resultado = servicoTaxa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Taxa> funcionarios = resultado.Value;

                listagemTaxa.AtualizarRegistros(funcionarios);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Funcionário",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
