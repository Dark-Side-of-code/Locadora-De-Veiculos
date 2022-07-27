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
        private TabelaFuncionarioControl? listagemFuncionarios;
        private readonly ServicoFuncionario servicoFuncionario;

        public ControladorDeFuncionario(ServicoFuncionario servicoFuncionario)
        {
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

        public override void Editar()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Edição de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoFuncionario.SelecionarPorId(id);

            if(resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                "Edição de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultado.Value;

            var tela = new TelaCadastroFuncionarioForm();

            tela.Funcionario = funcionarioSelecionado;

            tela.GravarRegistro = servicoFuncionario.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarFuncionarios();
        }

        public override void Excluir()
        {
            var id = listagemFuncionarios.ObtemIdFuncionarioSelecionado();

            if(id == Guid.Empty)
            {
                MessageBox.Show("Selecione um funcionário primeiro",
                "Exclusão de Funcionário", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            var resultadoSelecao = servicoFuncionario.SelecionarPorId(id);


            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var funcionarioSelecionado = resultadoSelecao.Value;

            if(MessageBox.Show("Deseja realmente excluir o funcionário?","Exclusão de Funcionário",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoFuncionario.Excluir(funcionarioSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarFuncionarios();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Funcionario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        
        private void CarregarFuncionarios()
        {
            var resultado = servicoFuncionario.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Funcionario> funcionarios = resultado.Value;

                listagemFuncionarios?.AtualizarRegistros(funcionarios);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {funcionarios.Count} funcionário(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de funcionário",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
