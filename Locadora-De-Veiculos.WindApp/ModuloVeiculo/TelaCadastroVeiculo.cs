using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Locadora_De_Veiculos.WindApp.ModuloVeiculo
{
    public partial class TelaCadastroVeiculo : Form
    {
        private Veiculo veiculo;
        public TelaCadastroVeiculo()
        {
            InitializeComponent();
            this.ConfigurarTela();
            ClassMaskValor.AplicaMascaraKm(txt_Km);
            ClassMaskValor.AplicaMascaraLitros(txt_Capacidade);
        }

        public Func<Veiculo, ValidationResult> GravarRegistro { get; set; }

        public Veiculo Veiculo
        {
            get => veiculo;

            set
            {
                veiculo = value;

                txt_Modelo.Text = veiculo.Modelo;
                txt_Marca.Text = veiculo.Marca;
                txt_Placa.Text = veiculo.Placa;
                txt_Km.Text = veiculo.Km_total.ToString();
                txt_Cor.Text = veiculo.Cor;
                comboBox_Categoria.SelectedItem = veiculo.CategoriaDeVeiculos;
                txt_Capacidade.Text = veiculo.Capacidade_tanque.ToString();
                comboBox_Tipo.SelectedItem = veiculo.Tipo_combustivel;

                if (veiculo.Ano > DateTimePicker.MinimumDateTime)
                {
                    datePicker_Ano.Value = veiculo.Ano;
                }
                else
                    datePicker_Ano.Value = DateTime.Now;
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            veiculo.Modelo = txt_Modelo.Text;
            veiculo.Marca = txt_Marca.Text;
            veiculo.Placa = txt_Placa.Text;
            veiculo.Km_total = Convert.ToDouble(txt_Km.Text.Replace("Km", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            veiculo.Cor = txt_Cor.Text;
            veiculo.CategoriaDeVeiculos = (CategoriaDeVeiculos)comboBox_Categoria.SelectedItem;
            veiculo.Capacidade_tanque = Convert.ToDouble(txt_Capacidade.Text.Replace("L", string.Empty).Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)); ;
            veiculo.Tipo_combustivel = comboBox_Categoria.SelectedItem.ToString();
            veiculo.Ano = datePicker_Ano.Value;


            var resultadoValidacao = GravarRegistro(Veiculo);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaInicioForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }
    }
}
