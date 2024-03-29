﻿using Locadora_De_Veiculos.Aplicacao.ModuloCategoriasDeVeiculos;
using Locadora_De_Veiculos.Aplicacao.ModuloCliente;
using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.Aplicacao.ModuloFuncionario;
using Locadora_De_Veiculos.Aplicacao.ModuloLocacao;
using Locadora_De_Veiculos.Aplicacao.ModuloPlanoDeCobranca;
using Locadora_De_Veiculos.Aplicacao.ModuloTaxas;
using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.ModuloDevolucao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public class ControladorDeLocacao : ControladorBase
    {
        
        private TabelaLocacaoControl? listagemLocacao;
        //private TabelaDevolucaoControl? listagemDevolucao;
        private readonly ServicoLocacao servicoLocacao;
        //private readonly ServicoDevolucao servicoDevolucao;
        private readonly ServicoFuncionario servicoFuncionario;
        private readonly ServicoCliente servicoCliente;
        private readonly ServicoCondutor servicoCondutor;
        private readonly ServicoCategoriasDeVeiculos servicoCategoria;
        private readonly ServicoVeiculo servicoVeiculo;
        private readonly ServicoPlanoDeCobranca servicoPlanoDeCobranca;
        private readonly ServicoTaxa servicoTaxa;

        List<Funcionario> funcionarios = new List<Funcionario>();
        List<Cliente> clientes = new List<Cliente>();
        List<Condutor> condutores = new List<Condutor>();
        List<CategoriaDeVeiculos> categorias = new List<CategoriaDeVeiculos>();
        List<Veiculo> veiculos = new List<Veiculo>();
        List<PlanoDeCobranca> planos = new List<PlanoDeCobranca>();
        List<Taxa> taxas = new List<Taxa>();

        public ControladorDeLocacao(ServicoLocacao servicoLocacao, ServicoFuncionario servicoFuncionario, ServicoCliente servicoCliente, ServicoCondutor servicoCondutor, ServicoCategoriasDeVeiculos servicoCategoria, ServicoVeiculo servicoVeiculo, ServicoPlanoDeCobranca servicoPlanoDeCobranca, ServicoTaxa servicoTaxa)
        {
            this.servicoLocacao = servicoLocacao;
            this.servicoFuncionario = servicoFuncionario;
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
            this.servicoCategoria = servicoCategoria;
            this.servicoVeiculo = servicoVeiculo;
            this.servicoPlanoDeCobranca = servicoPlanoDeCobranca;
            this.servicoTaxa = servicoTaxa;
        }

        public override void Inserir()
        {
            var resultadoFuncionario = servicoFuncionario.SelecionarTodos();
            if (resultadoFuncionario.IsSuccess)
                funcionarios = resultadoFuncionario.Value;

            if (funcionarios.Count == 0)
            {
                MessageBox.Show("Insira um funcionario primeiro",
               "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoCliente = servicoCliente.SelecionarTodos();
            if (resultadoCliente.IsSuccess)
                clientes = resultadoCliente.Value;

            if (clientes.Count == 0)
            {
                MessageBox.Show("Insira um cliente primeiro",
               "Inserção de Locacação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoCondutor = servicoCondutor.SelecionarTodos();
            if (resultadoCondutor.IsSuccess)
                condutores = resultadoCondutor.Value;

            if (clientes.Count == 0)
            {
                MessageBox.Show("Insira um condutor primeiro",
               "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoCategoria = servicoCategoria.SelecionarTodos();
            if (resultadoCategoria.IsSuccess)
                categorias = resultadoCategoria.Value;

            if (clientes.Count == 0)
            {
                MessageBox.Show("Insira um categoria primeiro",
               "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoVeiculo = servicoVeiculo.SelecionarTodos();
            if (resultadoVeiculo.IsSuccess)
                veiculos = resultadoVeiculo.Value;

            if (veiculos.Count == 0)
            {
                MessageBox.Show("Insira um veiculo primeiro",
               "Inserção de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoPlano = servicoPlanoDeCobranca.SelecionarTodos();
            if (resultadoPlano.IsSuccess)
                planos = resultadoPlano.Value;

            if (planos.Count == 0)
            {
                MessageBox.Show("Insira um plano de cobrança primeiro",
               "Inserção de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoTaxa = servicoTaxa.SelecionarTodos();
            if (resultadoTaxa.IsSuccess)
                taxas = resultadoTaxa.Value;

            if (taxas.Count == 0)
            {
                MessageBox.Show("Insira um taxa primeiro",
               "Inserção de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroLocacaoForm(funcionarios, clientes, condutores, categorias, veiculos, planos, taxas);

            tela.Locacao = new Locacao();

            tela.GravarRegistro = servicoLocacao.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarLocacao();
            }
        }

        public override void Editar()
        {
        }

        public override void Excluir()
        {
            var id = listagemLocacao.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma Locação primeiro",
                    "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoLocacao.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Locacao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;
            var locacao = servicoLocacao.SelecionarLocacaoPorID(id);
            locacao.Status = "Excluido";

            if (MessageBox.Show("Deseja realmente excluir a Locacao?", "Exclusão de Locacao",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoLocacao.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarLocacao();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void Devolver()
        {
            var id = listagemLocacao.ObtemIdLocacaoSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma dlocação primeiro",
                "Devoluções", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoLocacao.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Edição de Locação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var devolucaoSelecionada = resultado.Value;

            var tela = new TelaCadastroDevolucao(taxas, devolucaoSelecionada);

            tela.Locacao = devolucaoSelecionada;

            tela.Locacao.Status = "Devolvido";

            tela.GravarRegistro = servicoLocacao.Devolucao;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarLocacao();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxLocacao();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemLocacao == null)
                listagemLocacao = new TabelaLocacaoControl();

            CarregarLocacao();

            return listagemLocacao;
        }

        private void CarregarLocacao()
        {
            var resultado = servicoLocacao.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Locacao> locacoes = resultado.Value;

                listagemLocacao.AtualizarRegistros(locacoes);
                listagemLocacao.AtualizarRegistrosDevolucao(locacoes);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {locacoes.Count} Locações(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Locações",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
