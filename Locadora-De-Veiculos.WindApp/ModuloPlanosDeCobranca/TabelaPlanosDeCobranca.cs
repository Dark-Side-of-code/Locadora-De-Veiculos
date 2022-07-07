using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
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

namespace Locadora_De_Veiculos.WindApp.ModuloPlanosDeCobranca
{
    public partial class TabelaPlanosDeCobranca : UserControl
    {
        public TabelaPlanosDeCobranca()
        {
            InitializeComponent();
            grid.ConfigurarGridZebrado();
            grid.ConfigurarGridSomenteLeitura();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {

                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número", FillWeight = 15F },

                new DataGridViewTextBoxColumn { DataPropertyName = "CategoriaDeVeiculos.Nome", HeaderText = "Nome da Categoria", FillWeight = 85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDiario_ValorDiario", HeaderText = "Plano Diario Valor Por KM", FillWeight = 85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoDiario_ValorPorKM", HeaderText = "Plano Diario Valor Por KM", FillWeight = 85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoKM_Livre_ValorDiario", HeaderText = "Plano KM Livre Valor Diario", FillWeight = 85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "CategoriaDeVeiculos.Nome", HeaderText = "Plano KM Controlado Limite De Quilometragem", FillWeight = 85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoKM_controlado_ValorDiario", HeaderText = "Plano KM Controlado Valor Diario", FillWeight = 85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "PlanoKM_controlado_ValorPorKM", HeaderText = "Plano KM Controlado Valor Por KM", FillWeight = 85F },

            };
            return colunas;
        }

        public int ObtemIdPlanoDeCobrancaSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }

        public void AtualizarRegistros(List<PlanoDeCobranca> planoDeCobrancas)
        {
            grid.Rows.Clear();

            foreach(PlanoDeCobranca plano in planoDeCobrancas)
            {
                grid.Rows.Add(plano.Id, plano.CategoriaDeVeiculos.Nome,plano.PlanoDiario_ValorDiario, plano.PlanoDiario_ValorPorKM, plano.PlanoKM_Livre_ValorDiario, plano.PlanoKM_controlado_LimiteDeQuilometragem, plano.PlanoKM_controlado_ValorDiario, plano.PlanoKM_controlado_ValorPorKM);
            }
        }

    }
}
