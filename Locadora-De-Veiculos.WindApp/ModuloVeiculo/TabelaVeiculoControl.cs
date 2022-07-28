using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.Compartilhado.Funções;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloVeiculo
{
    public partial class TabelaVeiculoControl : UserControl
    {
        public TabelaVeiculoControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Marca", HeaderText = "Marca", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Cor", HeaderText = "Cor", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Tipo_combustivel", HeaderText = "Tipo de combustivel", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Capacidade_tanque", HeaderText = "Capacidade do tanque", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Ano", HeaderText = "Ano", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "Km_total", HeaderText = "Km_total", FillWeight=85F },

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoVeiculo", HeaderText = "Tipo de Veiculo", FillWeight=85F },

                new DataGridViewImageColumn { DataPropertyName = "Foto", HeaderText = "Foto", FillWeight=50F, ImageLayout=DataGridViewImageCellLayout.Stretch},
            };

            return colunas;
        }

        public Guid ObtemIdFuncionarioSelecionado()
        {
            return grid.SelecionarNumero<Guid>();
        }

        public void AtualizarRegistros(List<Veiculo> veiculos)
        {
            grid.Rows.Clear();

            foreach (Veiculo veiculo in veiculos)
            {
                grid.Rows.Add(veiculo.Id, veiculo.Modelo, veiculo.Placa, veiculo.Marca, veiculo.Cor, veiculo.Tipo_combustivel, veiculo.Capacidade_tanque, veiculo.Ano, veiculo.Km_total, veiculo.CategoriaDeVeiculos, ConversorDeImagemParaByteParaImagem.ConverteByteArrayParaImagem(veiculo.Foto));
            }
        }
    }
}
