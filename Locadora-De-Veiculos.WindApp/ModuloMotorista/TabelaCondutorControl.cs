using Locadora_De_Veiculos.Dominio.ModuloCondutor;
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

namespace Locadora_De_Veiculos.WindApp.ModuloMotorista
{
    public partial class TabelaCondutorControl : UserControl
    {
        public TabelaCondutorControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "CPF_CNPJ", HeaderText = "CPF/", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "CNH", HeaderText = "CNH", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Validade_CNH", HeaderText = "Validade da CNH", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Edereco", HeaderText = "Endereço", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cliente.Nome", HeaderText = "Nome Do Cliente", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemIdCondutorSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Condutor> condutors)
        {
            grid.Rows.Clear();

            foreach (Condutor condutor in condutors)
            {
                grid.Rows.Add(condutor.Id, condutor.Nome, condutor.CPF, condutor.Telefone, condutor.Email, condutor.CNH, condutor.Validade_CNH, condutor.Edereco, condutor.Cliente.Nome);
            }
        }
    }
}
