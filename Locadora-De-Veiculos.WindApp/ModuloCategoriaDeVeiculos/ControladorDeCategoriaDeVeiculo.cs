using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos
{
    internal class ControladorDeCategoriaDeVeiculo : ControladorBase
    {
        private readonly IRepositorioCategoriaDeVeiculos repositorioCategoriaDeVeiculos;
        private TabelaCategoriasDeVeiculosControl? listagemCategoriaDeVeiculos;
        private readonly ServicoCategoriasDeVeiculos servicoCategoriaDeVeiculos;

        public ControladorDeCategoriaDeVeiculo(IRepositorioCategoriaDeVeiculos repositorioCategoriaDeVeiculos, ServicoCategoriasDeVeiculos servicoCategoriaDeVeiculos)
        {
            this.repositorioCategoriaDeVeiculos = repositorioCategoriaDeVeiculos;
            this.servicoCategoriaDeVeiculos = servicoCategoriaDeVeiculos;
        }

        public override void Inserir()
        {
            var tela = new TelaDeCadastroDeCategoriaDeVeiculoForm();

            tela.CategoriaDeVeiculos = new CategoriaDeVeiculos();

            tela.GravarRegistro = servicoCategoriaDeVeiculos.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }
        }

        public override void Editar()
        {
            CategoriaDeVeiculos categoriaSelecionada = ObtemCategoriaDeVeiculoSelecionado();

            if (categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Edição de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaDeCadastroDeCategoriaDeVeiculoForm();

            tela.CategoriaDeVeiculos = (CategoriaDeVeiculos)categoriaSelecionada.Clone();

            tela.GravarRegistro = servicoCategoriaDeVeiculos.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarTaxas();
            }

        }

        public override void Excluir()
        {
            CategoriaDeVeiculos categoriaSelecionada = ObtemCategoriaDeVeiculoSelecionado();

            if (categoriaSelecionada == null)
            {
                MessageBox.Show("Selecione uma taxa primeiro",
                "Exclusão de Taxas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a taxa?",
               "Exclusão de Taxas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                try
                {
                    repositorioCategoriaDeVeiculos.Excluir(categoriaSelecionada);
                    CarregarTaxas();
                }catch(Exception e)
                {

                };
            }
        }

        private CategoriaDeVeiculos ObtemCategoriaDeVeiculoSelecionado()
        {
            var id = listagemCategoriaDeVeiculos.ObtemIdCategoriaVeiculoSelecionado();
            return repositorioCategoriaDeVeiculos.SelecionarPorNumero(id);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxCategoria();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCategoriaDeVeiculos == null)
                listagemCategoriaDeVeiculos = new TabelaCategoriasDeVeiculosControl();

            CarregarTaxas();

            return listagemCategoriaDeVeiculos;
        }

        private void CarregarTaxas()
        {
            List<CategoriaDeVeiculos> categorias = repositorioCategoriaDeVeiculos.SelecionarTodos();

            listagemCategoriaDeVeiculos?.AtualizarRegistros(categorias);

            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {categorias.Count} disciplina(s)");
        }
    }
}
