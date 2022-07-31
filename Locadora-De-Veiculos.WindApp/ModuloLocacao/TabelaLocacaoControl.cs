using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Número", FillWeight=15F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionario", FillWeight=15F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoria", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDeCobranca", HeaderText = "Plano", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataInicio", HeaderText = "Locacao", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataFinalPrevista", HeaderText = "Devolucao", FillWeight=85F },
            };

            return colunas;
        }

        public Guid ObtemIdLocacaoSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Locacao> locacoes)
        {
            grid.Rows.Clear();

            foreach (Locacao locacao in locacoes)
            {
                grid.Rows.Add(locacao.Id, locacao.Funcionario, locacao.Cliente, locacao.Condutor, locacao.Categoria, locacao.Veiculo, locacao.PlanoDeCobranca, locacao.DataInicio, locacao.DataFinalPrevista);
            }
        }
    }
}
