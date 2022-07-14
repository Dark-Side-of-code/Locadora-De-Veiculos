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
                CarregarCategoriaDeVeiculos();
            }
        }

        public override void Editar()
        {
            var id = listagemCategoriaDeVeiculos.ObtemIdCategoriaVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCategoriaDeVeiculos.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var CategoriaDeVeiculoSelecionado = resultado.Value;

            var tela = new TelaDeCadastroDeCategoriaDeVeiculoForm();

            tela.CategoriaDeVeiculos = (CategoriaDeVeiculos)CategoriaDeVeiculoSelecionado.Clone();

            tela.GravarRegistro = servicoCategoriaDeVeiculos.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCategoriaDeVeiculos();
        }

        public override void Excluir()
        {
            var id = listagemCategoriaDeVeiculos.ObtemIdCategoriaVeiculoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                    "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCategoriaDeVeiculos.SelecionarPorId(id);

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
                var resultadoExclusao = servicoCategoriaDeVeiculos.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCategoriaDeVeiculos();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            CarregarCategoriaDeVeiculos();

            return listagemCategoriaDeVeiculos;
        }

        private void CarregarCategoriaDeVeiculos()
        {
            var resultado = servicoCategoriaDeVeiculos.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<CategoriaDeVeiculos> funcionarios = resultado.Value;

                listagemCategoriaDeVeiculos.AtualizarRegistros(funcionarios);

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
