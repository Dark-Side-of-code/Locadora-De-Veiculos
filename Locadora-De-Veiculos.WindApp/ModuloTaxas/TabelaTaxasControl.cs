using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloTaxas
{
    public partial class TabelaTaxasControl : UserControl
    {
        public TabelaTaxasControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número", FillWeight=15F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Descricao", HeaderText = "Descrição", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Valor", HeaderText = "Valor", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoDeCobraca", HeaderText = "Cobrança", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemIdTaxaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Taxa> taxas)
        {
            grid.Rows.Clear();

            foreach (Taxa taxa in taxas)
            {
                grid.Rows.Add(taxa.Id, taxa.Nome, taxa.Descricao, taxa.Valor, taxa.TipoDeCobraca);
            }
        }
    }
}
