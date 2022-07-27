using Locadora_De_Veiculos.Aplicacao.ModuloCliente;
using Locadora_De_Veiculos.Aplicacao.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloMotorista
{
    public class ControladorCondutor : ControladorBase
    {
        private readonly ServicoCliente servicoCliente;
        private TabelaCondutorControl? listagemCondutor;
        private readonly ServicoCondutor servicoCondutor;

        public ControladorCondutor(ServicoCliente servicoCliente, ServicoCondutor servicoCondutor)
        {
            this.servicoCliente = servicoCliente;
            this.servicoCondutor = servicoCondutor;
        }

        public override void Inserir()
        {
            List<Cliente> clientes = new List<Cliente>();
           
            var resultadoCliente = servicoCliente.SelecionarTodos();
            if (resultadoCliente.IsSuccess)
                clientes = resultadoCliente.Value;
            
            if (clientes.Count == 0)
            {
                MessageBox.Show("Insira um cliente primeiro",
               "Inserção de Condutores", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            var tela = new TelaCadastroCondutorForm(clientes);

            tela.Condutor = new Condutor();

            tela.GravarRegistro = servicoCondutor.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarCondutor();
            }
        }

        public override void Editar()
        {
            var id = listagemCondutor.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = servicoCondutor.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var condutorSelecionado = resultado.Value;

            List<Cliente> clientes = new List<Cliente>();
            var resultadoCliente = servicoCliente.SelecionarTodos();
            if (resultadoCliente.IsSuccess)
                clientes = resultadoCliente.Value;

            var tela = new TelaCadastroCondutorForm(clientes);

            tela.Condutor = condutorSelecionado;

            tela.GravarRegistro = servicoCondutor.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarCondutor();
        }

        public override void Excluir()
        {
            var id = listagemCondutor.ObtemIdCondutorSelecionado();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione um condutor primeiro",
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = servicoCondutor.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var veiculoSelecionado = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir o condutor?", "Exclusão de Condutor",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = servicoCondutor.Excluir(veiculoSelecionado);

                if (resultadoExclusao.IsSuccess)
                    CarregarCondutor();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Condutor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxCondutor();
        }

        private void CarregarCondutor()
        {
            var resultado = servicoCondutor.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Condutor> condutores = resultado.Value;

                listagemCondutor.AtualizarRegistros(condutores);

                TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {condutores.Count} condutor(es)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Exclusão de Condutor",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            if (listagemCondutor == null)
                listagemCondutor = new TabelaCondutorControl();

            CarregarCondutor();

            return listagemCondutor;
        }
    }
}

