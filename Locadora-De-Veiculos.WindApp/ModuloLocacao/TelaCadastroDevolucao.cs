﻿using FluentResults;
using Locadora_De_Veiculos.Dominio.ModuloDevolucao;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloLocacao;
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

namespace Locadora_De_Veiculos.WindApp.ModuloDevolucao
{
    public partial class TelaCadastroDevolucao : Form
    {
        private Locacao locacao;


        public TelaCadastroDevolucao()
        {
            InitializeComponent();
            this.ConfigurarTela();
        }

        public Func<Locacao, Result<Locacao>> GravarRegistro { get; set; }


        public Locacao Locacao
        {
            get => locacao;

            set
            {
                lb_Funcionario.Text = locacao.Funcionario.Nome;
                lb_Cliente.Text = locacao.Cliente.Nome;
                lb_Condutor.Text = locacao.Condutor.Nome;
                lb_Categoria.Text = locacao.Categoria.Nome;
                lb_Veiculo.Text = locacao.Veiculo.Modelo;
                lb_DataLocacao.Text = locacao.DataInicio.ToString();
                lb_DevoluçãoPrevista.Text = locacao.DataFinalPrevista.ToString();
               
                //-----
                lb_PlanoCobranca.Text = locacao.PlanoDeCobranca.ToString();//-----
                                                                           //-----

                //List_taxasSelecionadas = locacao.



                //txt_QuilometragemVeiculo.Text = devolucao.QuilometragemDoVeiculo.ToString();
                //cbx_NivelTanque.Text = devolucao.NivelDoTanque.ToString();
                //txt_ValorGasolina.Text = devolucao.ValorGasolina.ToString();
                //dateTimePicker_DataDevolucao.Text = devolucao.Data_Da_Entrega.ToString();
                //lb_ValorTotal.Text = devolucao.ValorTotal.ToString();
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            locacao.Funcionario.Nome = lb_Funcionario.Text;
            locacao.Cliente.Nome = lb_Cliente.Text;
            locacao.Condutor.Nome = lb_Condutor.Text;
            locacao.Categoria.Nome = lb_Categoria.Text;
            locacao.Veiculo.Modelo = lb_Veiculo.Text;
            locacao.DataInicio = DateTime.Parse(lb_DataLocacao.Text);
            locacao.DataFinalPrevista = DateTime.Parse(lb_DevoluçãoPrevista.Text);

            //----
            //locacao.PlanoDeCobranca = Convert.ToDouble(lb_PlanoCobranca.Text);//----
            //----

            locacao.DataFinalReal = DateTime.Parse(dateTimePicker_DataDevolucao.Text);
            locacao.QuilometragemDoVeiculo = Convert.ToInt32(txt_QuilometragemVeiculo.Text);
            locacao.NivelDoTanque = Convert.ToDecimal(cbx_NivelTanque.Text);
            locacao.ValorGasolina = Convert.ToDouble(txt_ValorGasolina.Text);
            //locacao.TaxaAdicional = Convert.ToString(List_TaxaAdicionais.Text);
            locacao.Status = "Devolvido";

            locacao.ValorTotal = Convert.ToDouble(lb_ValorTotal.Text);
        }
    }
}