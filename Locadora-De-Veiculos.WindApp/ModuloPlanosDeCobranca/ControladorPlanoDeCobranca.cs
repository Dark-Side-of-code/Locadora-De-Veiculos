using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
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
        private TabelaPlanosDeCobranca? listagemPlanosDeCobranca;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoCategoriasDeVeiculos servicoCategoria;

        public ControladorPlanoDeCobranca(ServicoCategoriasDeVeiculos servicoCategoria, ServicoPlanoDeCobranca servicoPlanoDeCobranca)
        {
            this.servicoCategoria = servicoCategoria;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
        }        

        public override void Inserir()
        {
            List<CategoriaDeVeiculos> categorias = new List<CategoriaDeVeiculos>();
            var resultadoCategoria = servicoCategoria.SelecionarTodos();
            
            if (resultadoCategoria.IsSuccess)
                categorias = resultadoCategoria.Value;

            var tela = new TelaCadastroPlanoDeCobrancaForm(categorias);

            tela.Plano = new PlanoDeCobranca();
            
            tela.GravarRegistro = servicoPlanoDeCobranca.Inserir;
            
            DialogResult resultado = tela.ShowDialog();
            
            if(resultado == DialogResult.OK)
            {
                CarregarPlanosDeCobranca();
            }

        }

        public override void Editar()
        {
            var id = listagemPlanosDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            if(id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Edição de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            var resultado = servicoPlanoDeCobranca.SelecionarPorId(id);
            
            if(resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoSelecionado = resultado.Value;

            List<CategoriaDeVeiculos> categoria = new List<CategoriaDeVeiculos>();
            
            var resultadoCategoria = servicoCategoria.SelecionarTodos();
            
            if (resultadoCategoria.IsSuccess)
                categoria = resultadoCategoria.Value;

            var tela = new TelaCadastroPlanoDeCobrancaForm(categoria);

            tela.Plano = planoSelecionado.Clone();

            tela.GravarRegistro = servicoPlanoDeCobranca.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarPlanosDeCobranca();
        }

        public override void Excluir()
        {
            var id = listagemPlanosDeCobranca.ObtemIdPlanoDeCobrancaSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um plano primeiro",
                "Exclusão de Planos de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoPlanoDeCobranca.SelecionarPorId(id);

            if(resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var planoDeCobrancaSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o plano de cobrança?", "Exclusão de Plano De Cobrança",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoPlanoDeCobranca.Excluir(planoDeCobrancaSelecionado);

                if (resultadoExclusao.IsSuccess)
                CarregarPlanosDeCobranca();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
       
        private void CarregarPlanosDeCobranca()
        {
            var resultado = servicoPlanoDeCobranca.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<PlanoDeCobranca> plano = resultado.Value;
                
                listagemPlanosDeCobranca.AtualizarRegistros(plano);
                
                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {plano.Count} plano(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de plano de cobrança",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
