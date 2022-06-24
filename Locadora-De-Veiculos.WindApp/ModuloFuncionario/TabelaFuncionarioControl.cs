using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
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

namespace Locadora_De_Veiculos.WindApp.ModuloFuncionario
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Login", HeaderText = "Login", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Senha", HeaderText = "Senha", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Salario", HeaderText = "Salario", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "DataAdmissao", HeaderText = "Data Admissao", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoFuncionario", HeaderText = "Tipo de Funcionario", FillWeight=85F },
            };

            return colunas;
        }

        public int ObtemNumeroSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<Funcionario> disciplinas)
        {
            grid.Rows.Clear();

            foreach (Funcionario funcionario in disciplinas)
            {
                grid.Rows.Add(funcionario.Id, funcionario.Nome, funcionario.Login, funcionario.Senha, funcionario.Salario, funcionario.DataAdmissao, funcionario.TipoFuncionario);
            }
        }
    }
}
