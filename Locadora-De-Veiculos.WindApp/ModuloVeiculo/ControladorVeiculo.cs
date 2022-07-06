using Locadora_De_Veiculos.Aplicacao.ModuloVeiculo;
using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloVeiculo
{
    public class ControladorVeiculo : ControladorBase
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;
        private readonly IRepositorioCategoriaDeVeiculos repositorioCategoria;
        private TabelaVeiculoControl? listagemVeiculos;
        private readonly ServicoVeiculo servicoVeiculo;

        public ControladorVeiculo(IRepositorioVeiculo repositorioVeiculo, IRepositorioCategoriaDeVeiculos repositorioCategoria, ServicoVeiculo servicoVeiculo)
        {
            this.repositorioVeiculo = repositorioVeiculo;
            this.repositorioCategoria = repositorioCategoria;
            this.servicoVeiculo = servicoVeiculo;
        }

        public override void Inserir()
        {
            var categorias = repositorioCategoria.SelecionarTodos();
            var tela = new TelaCadastroVeiculo(categorias);
            tela.Veiculo = new Veiculo();
            tela.GravarRegistro = servicoVeiculo.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarVeiculos();
            }
        }

        private void CarregarVeiculos()
        {
            List<Veiculo> veiculos = repositorioVeiculo.SelecionarTodos();
            listagemVeiculos?.AtualizarRegistros(veiculos);
            TelaInicioForm.Instancia.AtualizarRodape($"Visualizando {veiculos.Count} veiculos(s)");
        }

        public override void Editar()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Edição de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var categorias = repositorioCategoria.SelecionarTodos();
            TelaCadastroVeiculo tela = new TelaCadastroVeiculo(categorias);

            tela.Veiculo = veiculoSelecionado.Clone();

            tela.GravarRegistro = servicoVeiculo.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarVeiculos();
        }

        public override void Excluir()
        {
            Veiculo veiculoSelecionado = ObtemVeiculoSelecionado();

            if (veiculoSelecionado == null)
            {
                MessageBox.Show("Selecione um veiculo primeiro",
                "Exclusão de Veiculo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o veiculo?",
                "Exclusão de Veiculo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
                repositorioVeiculo.Excluir(veiculoSelecionado);

            CarregarVeiculos();
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

        private Veiculo ObtemVeiculoSelecionado()
        {
            var id = listagemVeiculos.ObtemIdFuncionarioSelecionado();

            return repositorioVeiculo.SelecionarPorNumero(id);
        }
    }
}
