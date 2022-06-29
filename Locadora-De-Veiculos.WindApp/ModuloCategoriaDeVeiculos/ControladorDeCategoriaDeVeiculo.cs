using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloGrupoDeVeiculos;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos
{
    internal class ControladorDeCategoriaDeVeiculo : ControladorBase
    {
        private RepositorioCategoriaDeVeiculosEmBancoDados repositorio;
        private TabelaCategoriasDeVeiculosControl tabela;

        public ControladorDeCategoriaDeVeiculo(RepositorioCategoriaDeVeiculosEmBancoDados repositorioTaxa)
        {
            this.repositorio = repositorioTaxa;
        }

        public override void Inserir()
        {
            var tela = new TelaDeCadastroDeCategoriaDeVeiculoForm();

            tela.CategoriaDeVeiculos = new CategoriaDeVeiculos();

            tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            var numero = tabela.ObtemIdCategoriaVeiculoSelecionado();

            CategoriaDeVeiculos categoriaSelecionada = repositorio.SelecionarPorId(numero);

            if (categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Edição de Compromissos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaDeCadastroDeCategoriaDeVeiculoForm();

            tela.CategoriaDeVeiculos = (CategoriaDeVeiculos)categoriaSelecionada.Clone();

            tela.GravarRegistro = repositorio.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }

        }

        public override void Excluir()
        {
            var numero = tabela.ObtemIdCategoriaVeiculoSelecionado();

            CategoriaDeVeiculos categoriaSelecionada = repositorio.SelecionarPorId(numero);

            if (categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma disciplina primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a disciplina?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorio.Excluir(categoriaSelecionada);
                CarregarTaxas();
            }
        }


        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxCategoria();
        }

        public override UserControl ObtemListagem()
        {
            if (tabela == null)
                tabela = new TabelaCategoriasDeVeiculosControl();

            CarregarTaxas();

            return tabela;
        }

        private void CarregarTaxas()
        {
            List<CategoriaDeVeiculos> categorias = repositorio.SelecionarTodos();

            tabela.AtualizarRegistros(categorias);

            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {categorias.Count} disciplina(s)");
        }
    }
}
