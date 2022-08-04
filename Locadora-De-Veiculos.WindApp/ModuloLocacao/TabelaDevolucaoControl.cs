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
            gridDevolucao.ConfigurarGridZebrado();
            gridDevolucao.ConfigurarGridSomenteLeitura();
            gridDevolucao.Columns.AddRange(ObterColunasDevolucao());
        }

        public DataGridViewColumn[] ObterColunasDevolucao()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Funcionario", HeaderText = "Funcionario", FillWeight=15F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente", HeaderText = "Cliente", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Categoria", HeaderText = "Categoria", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Veiculo", HeaderText = "Veiculo", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDeCobranca", HeaderText = "Plano", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "QuilometragemDoVeiculo", HeaderText = "Quilometragem do veículo", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "NivelDoTanque", HeaderText = "Nível do Tanque", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorGasolina", HeaderText = "Preço gasolina", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "TaxaAdicional", HeaderText = "Taxa Adicional", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "TaxaSelecionada", HeaderText = "Taxa Selecionada", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataInicio", HeaderText = "Data Inicio", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataFinalPrevista", HeaderText = "Data Final Prevista", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Data_Da_Entrega", HeaderText = "Data Da Entrega", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorTotal", HeaderText = "Valor Total", FillWeight=85F },



            };

            return colunas;
        }


        public Guid ObtemIdDevolucaoSelecionada()
        {
            return gridDevolucao.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Devolucao> devolucoes)
        {
            gridDevolucao.Rows.Clear();

            foreach (Devolucao devolucao in devolucoes)
            {
                gridDevolucao.Rows.Add(devolucao.Id, devolucao.Funcionario, devolucao.Cliente, devolucao.Condutor, devolucao.Categoria, devolucao.Veiculo, devolucao.PlanoDeCobranca, devolucao.QuilometragemDoVeiculo, devolucao.NivelDoTanque, devolucao.ValorGasolina,/**/ devolucao.TaxaAdicional, devolucao.TaxaSelecionada,/**/ devolucao.Data_Inicio_Locacao.ToString("dd/MM/yyyy"), devolucao.Data_Final_Prevista.ToString("dd/MM/yyyy"), devolucao.Data_Da_Entrega.ToString("dd/MM/yyyy"), devolucao.ValorTotal);
            }
        }
    }
}
