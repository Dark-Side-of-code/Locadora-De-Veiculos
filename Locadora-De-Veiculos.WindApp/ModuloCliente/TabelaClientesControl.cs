using Locadora_De_Veiculos.Dominio.ModuloCliente;
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

namespace Locadora_De_Veiculos.WindApp.ModuloCliente
{
    public partial class TabelaClientesControl : UserControl
    {
        public TabelaClientesControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF_CNPJ", HeaderText = "CPF/CNPJ", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Validade_CNH", HeaderText = "Validade da CNH", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo_Cliente", HeaderText = "Tipo do cliente", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemNumeroSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Cliente> clientes)
        {
            grid.Rows.Clear();

            foreach (Cliente cliente in clientes)
            {
                grid.Rows.Add(cliente.Id, cliente.Nome, cliente.CPF_CNPJ, cliente.Telefone, cliente.Email, cliente.CNH, cliente.Validade_CNH, cliente.Tipo_Cliente);
            }
        }
    }
}
