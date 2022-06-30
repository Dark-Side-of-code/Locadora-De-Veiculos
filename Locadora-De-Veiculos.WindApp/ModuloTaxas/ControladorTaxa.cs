using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloTaxas
{
    public class ControladorTaxa : ControladorBase
    {
        private readonly IRepositorioTaxa repositorioTaxa;
        private TabelaTaxasControl? listagemTaxas;
        private readonly ServicoTaxa servicoTaxa;

        public ControladorTaxa(IRepositorioTaxa repositorioTaxa, ServicoTaxa servicoTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
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
                CarregarTaxas();
            }
        }
        
        public override void Editar()
        {
            Taxa disciplinaSelecionada = ObtemTaxaSelecionada();
        
            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        
            var tela = new TelaCadastroDeTaxasForm();
        
            tela.Taxa = (Taxa)disciplinaSelecionada.Clone();
        
            tela.GravarRegistro = servicoTaxa.Editar;
        
            DialogResult resultado = tela.ShowDialog();
        
            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        
        }

        private Taxa ObtemTaxaSelecionada()
        {
            var id = listagemTaxas.ObtemIdTaxaSelecionada();

            return repositorioTaxa.SelecionarPorNumero(id);
        }

        public override void Excluir()
        {
            Taxa disciplinaSelecionada = ObtemTaxaSelecionada();
        
            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        
            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        
            if (resultado == DialogResult.OK)
            {
                repositorioTaxa.Excluir(disciplinaSelecionada);
                CarregarTaxas();
            }
        }
        
        
        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxTaxa();
        }
        
        public override UserControl ObtemListagem()
        {
            if (listagemTaxas == null)
                listagemTaxas = new TabelaTaxasControl();
        
            CarregarTaxas();
        
            return listagemTaxas;
        }
        
        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();
        
            listagemTaxas?.AtualizarRegistros(taxas);
        
            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} disciplina(s)");
        }
    }
}
