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
        private RepositorioFuncionarioEmBancoDados repositorioFuncionario;
        private TabelaFuncionarioControl tabelaFuncionario;

        public ControladorDeFuncionario()
        {
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = new Funcionario();

            tela.GravarRegistro = repositorioFuncionario.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }
        }

        public override void Editar()
        {
            var numero = tabelaFuncionario.ObtemNumeroSelecionado();

            Funcionario disciplinaSelecionada = repositorioFuncionario.SelecionarPorId(numero);

            if (disciplinaSelecionada == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Edição de Funcionarios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = (Funcionario)disciplinaSelecionada.Clone();

            tela.GravarRegistro = repositorioFuncionario.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarFuncionarios();
            }

        }

        public override void Excluir()
        {
            var numero = tabelaFuncionario.ObtemNumeroSelecionado();

            Funcionario funcionarioSelecionada = repositorioFuncionario.SelecionarPorId(numero);

            if (funcionarioSelecionada == null)
            {
                MessageBox.Show("Selecione um funcionario primeiro",
                "Exclusão de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a funcionario?",
               "Exclusão de Funcionario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioFuncionario.Excluir(funcionarioSelecionada);
                CarregarFuncionarios();
            }
        }
    

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoTollboxFuncionario();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaFuncionario == null)
                tabelaFuncionario = new TabelaFuncionarioControl();
            
            CarregarFuncionarios();

            return tabelaFuncionario;
        }


        private void CarregarFuncionarios()
        {
            List<Funcionario> funcionarios = repositorioFuncionario.SelecionarTodos();

            tabelaFuncionario.AtualizarRegistros(funcionarios);

            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionario(s)");
        }

    }
}
