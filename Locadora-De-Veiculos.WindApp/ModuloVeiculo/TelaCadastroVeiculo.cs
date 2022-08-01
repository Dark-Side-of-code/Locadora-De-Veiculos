using FluentResults;
using FluentValidation.Results;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.WindApp.Compartilhado;
using Locadora_De_Veiculos.WindApp.Compartilhado.Funções;
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
        private List<CategoriaDeVeiculos> categoria;

        public TelaCadastroVeiculo(List<CategoriaDeVeiculos> categoria)
        {
            this.categoria = categoria;
            InitializeComponent();
            this.ConfigurarTela();
            CarregarCategoriaDeVeiculos(categoria);
            ClassMaskValorNumerico.AplicaMascaraValorNumerico(txt_Capacidade);
            ClassMaskValorNumerico.AplicaMascaraValorNumerico(txt_Km);
        }

        public Func<Veiculo, Result<Veiculo>> GravarRegistro { get; set; }

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
                pictureBoxFoto.Image = ConversorDeImagemParaByteParaImagem.ConverteByteArrayParaImagem(veiculo.Foto);
                if (veiculo.Tipo_combustivel != null)
                {
                    comboBox_Tipo.SelectedItem = veiculo.Tipo_combustivel;
                    comboBox_Tipo.SelectedIndex = 0;
                }
                else
                {
                    comboBox_Tipo.SelectedIndex = 0;
                }

                if (veiculo.CategoriaDeVeiculos != null)
                {
                    comboBox_Categoria.SelectedItem = veiculo.Tipo_combustivel;
                    comboBox_Categoria.SelectedIndex = 0;
                }
                else
                {
                    comboBox_Categoria.SelectedIndex = 0;
                }

                if (veiculo.Ano > DateTimePicker.MinimumDateTime)
                {
                    datePicker_Ano.Value = veiculo.Ano;
                }
                else
                    datePicker_Ano.Value = DateTime.Now;
            }
        }

        private void CarregarCategoriaDeVeiculos(List<CategoriaDeVeiculos> categoria)
        {
            comboBox_Categoria.Items.Clear();

            foreach (CategoriaDeVeiculos item in categoria)
            {
                comboBox_Categoria.Items.Add(item);
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            veiculo.Modelo = txt_Modelo.Text;
            veiculo.Marca = txt_Marca.Text;
            veiculo.Placa = txt_Placa.Text;
            veiculo.Km_total = Convert.ToDouble(txt_Km.Text);
            veiculo.Cor = txt_Cor.Text;
            veiculo.CategoriaDeVeiculos = (CategoriaDeVeiculos)comboBox_Categoria.SelectedItem;
            veiculo.Capacidade_tanque = Convert.ToDouble(txt_Capacidade.Text);
            veiculo.Tipo_combustivel = comboBox_Tipo.SelectedItem.ToString();
            veiculo.Ano = datePicker_Ano.Value;
            veiculo.Foto = ConversorDeImagemParaByteParaImagem.ConverteImagemParaByteArray(pictureBoxFoto.Image);

            var resultadoValidacao = GravarRegistro(Veiculo);

            if (resultadoValidacao.IsFailed)
            {
                string erro = resultadoValidacao.Errors[0].Message;

                if (erro.StartsWith("Falha no sistema"))
                {
                    MessageBox.Show(erro,
                    "Inserção de Veículo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    TelaInicioForm.Instancia.AtualizarRodape(erro);

                    DialogResult = DialogResult.None;
                }
            }
        }

        private void pictureBoxFoto_Click(object sender, EventArgs e)
        {
            openFileDialogImage.Title = "Imagem do Veiculo";
            openFileDialogImage.Filter = "Images (*.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.)| *.JPEG; *.BMP; *.JPG; *.GIF; *.PNG; *.icon; *.JFIF";
            if (openFileDialogImage.ShowDialog() == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(openFileDialogImage.FileName);
                pictureBoxFoto.Image = new Bitmap(pictureBoxFoto.Image, new Size(130, 98));
                pictureBoxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
