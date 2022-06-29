using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
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

namespace Locadora_De_Veiculos.WindApp.ModuloCategoriaDeVeiculos
{
    public partial class TabelaCategoriasDeVeiculosControl : UserControl
    {
        public TabelaCategoriasDeVeiculosControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome", FillWeight=85F }
            };

            return colunas;
        }

        public int ObtemIdCategoriaVeiculoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<CategoriaDeVeiculos> disciplinas)
        {
            grid.Rows.Clear();
             
            foreach (CategoriaDeVeiculos disciplina in disciplinas)
            {
                grid.Rows.Add(disciplina.Id, disciplina.Nome);
            }
        }
    }
}
