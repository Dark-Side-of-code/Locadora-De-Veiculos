using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly ServicoCategoriasDeVeiculos servicoCategoria;
        private TabelaVeiculoControl listagemVeiculos;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(ServicoCategoriasDeVeiculos servicoCategoria, ServicoVeiculo servicoVeiculo)
        {
            this.servicoCategoria = servicoCategoria;
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            List<CategoriaDeVeiculos> categorias = new List<CategoriaDeVeiculos>();
            
            var resultadoCategoria = servicoCategoria.SelecionarTodos();
            
            if (resultadoCategoria.IsSuccess)
                categorias = resultadoCategoria.Value;

            if (categorias.Count == 0)
            {
                MessageBox.Show("Insira uma categoria primeiro",
               "Inserção de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
                

            var tela = new TelaCadastroVeiculo(categorias);

            tela.Veiculo = new Veiculo();
            tela.Veiculo.StatusVeiculo = true;

            tela.GravarRegistro = servicoVeiculo.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        public override void Editar()
        {
            var id = listagemVeiculos.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoVeiculo.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultado.Value;

            List<CategoriaDeVeiculos> categorias = new List<CategoriaDeVeiculos>();
            var resultadoCategoria = servicoCategoria.SelecionarTodos();
            if (resultadoCategoria.IsSuccess)
                categorias = resultadoCategoria.Value;

            var tela = new TelaCadastroVeiculo(categorias);

            tela.Veiculo = veiculoSelecionado;

            tela.GravarRegistro = servicoVeiculo.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            var id = listagemVeiculos.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um veículo primeiro",
                    "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoVeiculo.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o veículo?", "Exclusão de Veículo",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoVeiculo.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTolBoxVeiculo();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemVeiculos == null)
                listagemVeiculos = new TabelaVeiculoControl();

            CarregarVeiculos();

            return listagemVeiculos;
        }

        private void CarregarVeiculos()
        {
            var resultado = servicoVeiculo.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Veiculo> veiculos = resultado.Value;

                listagemVeiculos.AtualizarRegistros(veiculos);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veículo(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Seleção de Veículo",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
