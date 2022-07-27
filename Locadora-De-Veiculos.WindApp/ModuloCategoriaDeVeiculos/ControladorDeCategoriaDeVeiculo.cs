using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos
{
    internal class ControladorDeCategoriaDeVeiculo : ControladorBase
    {
        private TabelaCategoriasDeVeiculosControl? listagemCategoriaDeVeiculos;
        private readonly ServicoCategoriasDeVeiculos servicoCategoriaDeVeiculos;

        public ControladorDeCategoriaDeVeiculo(ServicoCategoriasDeVeiculos servicoCategoriaDeVeiculos)
        {
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
                CarregarCategoriaDeVeiculos();
            }
        }

        public override void Editar()
        {
            var id = listagemCategoriaDeVeiculos.ObtemIdCategoriaVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma categoria primeiro",
                    "Edição de Categoria de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCategoriaDeVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Categoria de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var CategoriaDeVeiculoSelecionado = resultado.Value;

            var tela = new TelaDeCadastroDeCategoriaDeVeiculoForm();

            tela.CategoriaDeVeiculos = CategoriaDeVeiculoSelecionado;

            tela.GravarRegistro = servicoCategoriaDeVeiculos.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCategoriaDeVeiculos();
        }

        public override void Excluir()
        {
            var id = listagemCategoriaDeVeiculos.ObtemIdCategoriaVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma categoria primeiro",
                    "Exclusão de Categoria de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCategoriaDeVeiculos.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Categoria de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var categoriaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a categoria?", "Exclusão de Categoria de Veículos",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCategoriaDeVeiculos.Excluir(categoriaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarCategoriaDeVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Categoria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxCategoria();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCategoriaDeVeiculos == null)
                listagemCategoriaDeVeiculos = new TabelaCategoriasDeVeiculosControl();

            CarregarCategoriaDeVeiculos();

            return listagemCategoriaDeVeiculos;
        }

        private void CarregarCategoriaDeVeiculos()
        {
            var resultado = servicoCategoriaDeVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<CategoriaDeVeiculos> categorias = resultado.Value;

                listagemCategoriaDeVeiculos.AtualizarRegistros(categorias);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {categorias.Count} categoria(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Categoria de Veículos",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
