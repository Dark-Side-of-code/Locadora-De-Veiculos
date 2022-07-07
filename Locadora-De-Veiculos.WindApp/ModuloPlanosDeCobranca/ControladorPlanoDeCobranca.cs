using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca
{
    public class ControladorPlanoDeCobranca : ControladorBase
    {
        private readonly IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca;
        private readonly IRepositorioCategoriaDeVeiculos repositorioCategoria;
        private TabelaPlanosDeCobranca listagemPlanosDeCobranca;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;

        public ControladorPlanoDeCobranca(IRepositorioPlanoDeCobranca repositorioPlanoDeCobranca, IRepositorioCategoriaDeVeiculos repositorioCategoria, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            this.repositorioPlanoDeCobranca = repositorioPlanoDeCobranca;
            this.repositorioCategoria = repositorioCategoria;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
                
        }

        public override void Inserir()
        {
            var categorias = repositorioCategoria.SelecionarTodos();
            var tela = new TelaCadastroPlanoDeCobrancaForm(categorias);
            tela.Plano = new PlanoDeCobranca();
            tela.GravarRegistro = servicoPlanoDeCobranca.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if(resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }

        }

        private void CarregarPlanosDeCobranca()
        {
            List<PlanoDeCobranca> plano = repositorioPlanoDeCobranca.SelecionarTodos();
            listagemPlanosDeCobranca?.AtualizarRegistros(plano);
            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {plano.Count} plano(s)");
        }

        public override void Editar()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if(planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Edição de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            var categoria = repositorioCategoria.SelecionarTodos();
            TelaCadastroPlanoDeCobrancaForm tela = new TelaCadastroPlanoDeCobrancaForm(categoria);

            tela.Plano = planoSelecionado.Clone();

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }

        }

        public override void Excluir()
        {
            PlanoDeCobranca planoSelecionado = ObtemPlanoSelecionado();

            if (planoSelecionado == null)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o plano de cobrança?",
                "Exclusão de Planos De Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioPlanoDeCobranca.Excluir(planoSelecionado);

            CarregarPlanosDeCobranca();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxPlanoDeCobranca();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemPlanosDeCobranca == null)
                listagemPlanosDeCobranca = new TabelaPlanosDeCobranca();

            CarregarPlanosDeCobranca();

            return listagemPlanosDeCobranca;
        }
        private PlanoDeCobranca ObtemPlanoSelecionado()
        {
            var id = listagemPlanosDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            return repositorioPlanoDeCobranca.SelecionarPorNumero(id);
        }
    }
}
