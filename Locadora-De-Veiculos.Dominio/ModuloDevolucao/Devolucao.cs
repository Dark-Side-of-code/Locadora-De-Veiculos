using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;

namespace Locadora_De_Veiculos.Dominio.ModuloDevolucao
{
    public class Devolucao : EntidadeBase<Devolucao>
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Condutor Condutor { get; set; }
        public CategoriaDeVeiculos Categoria { get; set; }
        public Veiculo Veiculo { get; set; }
        public PlanoDeCobranca PlanoDeCobranca { get; set; }
        public DateTime Data_Inicio_Locacao { get; set; }
        public DateTime Data_Final_Prevista { get; set; }
       
        public DateTime Data_Da_Entrega{ get; set; }
        public int QuilometragemDoVeiculo { get; set; }
        public double ValorGasolina { get; set; }
        public decimal NivelDoTanque{ get; set; }
        public double ValorTotal { get; set; }

        public List<Taxa> TaxaSelecionada { get; set; }
        public List<Taxa> TaxaAdicional { get; set; }


        public Devolucao()
        {

        }

        public Devolucao(Funcionario funcionario, Cliente cliente, Condutor condutor, CategoriaDeVeiculos categoria, Veiculo veiculo, PlanoDeCobranca planoDeCobranca, DateTime data_Inicio_Locacao, DateTime data_Final_Prevista, DateTime data_Da_Entrega, int quilometragemDoVeiculo, double valorGasolina, decimal nivelDoTanque, double valorTotal):this()
        {
            Funcionario = funcionario;
            Cliente = cliente;
            Condutor = condutor;
            Categoria = categoria;
            Veiculo = veiculo;
            PlanoDeCobranca = planoDeCobranca;
            Data_Inicio_Locacao = data_Inicio_Locacao;
            Data_Final_Prevista = data_Final_Prevista;
            
            Data_Da_Entrega = data_Da_Entrega;
            QuilometragemDoVeiculo = quilometragemDoVeiculo;
            ValorGasolina = valorGasolina;
            NivelDoTanque = nivelDoTanque;
            ValorTotal = valorTotal;
        }

        public Devolucao Clone()
        {
            return MemberwiseClone() as Devolucao;
        }

        public override bool Equals(object obj)
        {
            return obj is Devolucao devolucao &&
                   Id.Equals(devolucao.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, devolucao.Funcionario) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, devolucao.Cliente) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, devolucao.Condutor) &&
                   EqualityComparer<CategoriaDeVeiculos>.Default.Equals(Categoria, devolucao.Categoria) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, devolucao.Veiculo) &&
                   EqualityComparer<PlanoDeCobranca>.Default.Equals(PlanoDeCobranca, devolucao.PlanoDeCobranca) &&
                   Data_Inicio_Locacao == devolucao.Data_Inicio_Locacao &&
                   Data_Final_Prevista == devolucao.Data_Final_Prevista &&
                   Data_Da_Entrega == devolucao.Data_Da_Entrega &&
                   QuilometragemDoVeiculo == devolucao.QuilometragemDoVeiculo &&
                   ValorGasolina == devolucao.ValorGasolina &&
                   NivelDoTanque == devolucao.NivelDoTanque &&
                   ValorTotal == devolucao.ValorTotal &&
                   EqualityComparer<List<Taxa>>.Default.Equals(TaxaSelecionada, devolucao.TaxaSelecionada) &&
                   EqualityComparer<List<Taxa>>.Default.Equals(TaxaAdicional, devolucao.TaxaAdicional);
        }
    }
}
