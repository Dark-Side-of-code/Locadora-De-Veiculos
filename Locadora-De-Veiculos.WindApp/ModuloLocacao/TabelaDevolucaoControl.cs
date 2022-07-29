using Locadora_De_Veiculos.Dominio.ModuloDevolucao;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloLocacao
{
    public partial class TabelaDevolucaoControl : UserControl
    {
        public TabelaDevolucaoControl()
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


        public Guid ObtemIdDevolucaoSelecionada()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            grid.Rows.Clear();

            foreach (Devolucao devolucao in devolucoes)
            {
                grid.Rows.Add(devolucao.Id, devolucao.Funcionario, devolucao.Cliente, devolucao.Condutor, devolucao.Categoria, devolucao.Veiculo, devolucao.PlanoDeCobranca, devolucao.QuilometragemDoVeiculo, devolucao.NivelDoTanque, devolucao.ValorGasolina,/**/ devolucao.TaxaAdicional, devolucao.TaxaSelecionada,/**/ devolucao.Data_Inicio_Locacao, devolucao.Data_Final_Prevista, devolucao.Data_Da_Entrega, devolucao.ValorTotal);
            }
        }
    }
}
