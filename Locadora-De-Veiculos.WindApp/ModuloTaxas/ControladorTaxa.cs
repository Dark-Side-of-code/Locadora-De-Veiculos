using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloTaxas
{
    public class ControladorTaxa : ControladorBase
    {
        private RepositorioTaxaEmBancoDados repositorioTaxa;
        private TabelaTaxasControl tabelaTaxas;

        public ControladorTaxa(RepositorioTaxaEmBancoDados repositorioTaxa)
        {
            this.repositorioTaxa = repositorioTaxa;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroDeTaxasForm();
        
            tela.Taxa = new Taxa();
        
            tela.GravarRegistro = repositorioTaxa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }
        
        public override void Editar()
        {
            var numero = tabelaTaxas.ObtemIdTaxaSelecionada();
        
            Taxa disciplinaSelecionada = repositorioTaxa.SelecionarPorId(numero);
        
            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        
            var tela = new TelaCadastroDeTaxasForm();
        
            tela.Taxa = (Taxa)disciplinaSelecionada.Clone();
        
            tela.GravarRegistro = repositorioTaxa.Editar;
        
            DialogResult resultado = tela.ShowDialog();
        
            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        
        }
        
        public override void Excluir()
        {
            var numero = tabelaTaxas.ObtemIdTaxaSelecionada();
        
            Taxa disciplinaSelecionada = repositorioTaxa.SelecionarPorId(numero);
        
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
            if (tabelaTaxas == null)
                tabelaTaxas = new TabelaTaxasControl();
        
            CarregarTaxas();
        
            return tabelaTaxas;
        }
        
        private void CarregarTaxas()
        {
            List<Taxa> taxas = repositorioTaxa.SelecionarTodos();
        
            tabelaTaxas.AtualizarRegistros(taxas);
        
            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {taxas.Count} disciplina(s)");
        }
    }
}
