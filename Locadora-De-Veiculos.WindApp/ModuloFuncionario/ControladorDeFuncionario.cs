using Locadora_De_Veiculos.Aplicacao.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Banco.ModuloFuncionario;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloFuncionario
{
    public class ControladorDeFuncionario : ControladorBase
    {
        private readonly IRepositorioFuncionario repositorioFuncionario;
        private TabelaFuncionarioControl? listagemFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorDeFuncionario(IRepositorioFuncionario repositorioFuncionario, ServicoFuncionario servicoFuncionario)
        {
            this.repositorioFuncionario = repositorioFuncionario;
            this.servicoFuncionario = servicoFuncionario;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroFuncionarioForm();
            tela.Funcionario = new Funcionario();
            tela.GravarRegistro = servicoFuncionario.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();
            listagemFuncionarios?.AtualizarRegistros(funcionarios);
            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
        }

        public override void Editar()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroFuncionarioForm tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado.Clone();

            tela.GravarRegistro = servicoFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            Funcionario funcionarioSelecionado = ObtemFuncionarioSelecionado();

            if (funcionarioSelecionado == null)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o funcionário?",
                "Exclusão de Funcionário", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                    repositorioFuncionario.Excluir(funcionarioSelecionado);
                    
            CarregarFuncionarios();
        }



        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (listagemFuncionarios == null)
                listagemFuncionarios = new TabelaFuncionarioControl();

            CarregarFuncionarios();

            return listagemFuncionarios;
        }

        private Funcionario ObtemFuncionarioSelecionado()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            return repositorioFuncionario.SelecionarPorNumero(id);
        }
    }
}
