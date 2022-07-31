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

namespace Locadora_De_Veiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Funcionario Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid ClienteId { get; set; }
        public Condutor Condutor { get; set; }
        public Guid CondutorId { get; set; }
        public CategoriaDeVeiculos Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public Veiculo Veiculo { get; set; }
        public Guid VeiculoId { get; set; }
        public PlanoDeCobranca PlanoDeCobranca { get; set; }
        public Guid PlanoDeCobrancaId { get; set; }
        public List<Taxa> Taxas { get; set; }
        public string NomeDoPlano { get; set; }
        public double valorEstimado { get; set; }
        public string Status { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinalPrevista { get; set; }

        //Atributos Relacionados A Devolucao

        public DateTime DataFinalReal { get; set; }
        public int QuilometragemDoVeiculo { get; set; }
        public double ValorGasolina { get; set; }
        public decimal NivelDoTanque { get; set; }
        public double ValorTotal { get; set; }
        public List<Taxa> TaxaAdicional { get; set; }

        public Locacao()
        {

        }

        public Locacao(Funcionario funcionario, Cliente cliente, Condutor condutor, CategoriaDeVeiculos categoria, Veiculo veiculo, PlanoDeCobranca planoDeCobranca, DateTime dataInicio, DateTime dataFinal)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            Condutor = condutor;
            Categoria = categoria;
            Veiculo = veiculo;
            PlanoDeCobranca = planoDeCobranca;
            DataInicio = dataInicio;
            DataFinalPrevista = dataFinal;
            Status = "Em Aberto";
        }
        public override bool Equals(object obj)
        {
            return obj is Locacao locacao &&
                   Id.Equals(locacao.Id) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, locacao.Funcionario) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, locacao.Cliente) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, locacao.Condutor) &&
                   EqualityComparer<CategoriaDeVeiculos>.Default.Equals(Categoria, locacao.Categoria) &&
                   EqualityComparer<Veiculo>.Default.Equals(Veiculo, locacao.Veiculo) &&
                   EqualityComparer<PlanoDeCobranca>.Default.Equals(PlanoDeCobranca, locacao.PlanoDeCobranca) &&
                   DataInicio == locacao.DataInicio &&
                   DataFinalPrevista == locacao.DataFinalPrevista;
        }

        public Condutor Clone()
        {
            return MemberwiseClone() as Condutor;
        }

        public void ConfigurarLocacao(Funcionario funcionario, Cliente cliente, Condutor condutor, CategoriaDeVeiculos categoria,
        Veiculo veiculo, PlanoDeCobranca planoDeCobranca, List<Taxa> taxa)
        {
            if (funcionario == null)
                return;

            Funcionario = funcionario;
            FuncionarioId = funcionario.Id;

            if (cliente == null)
                return;

            Cliente = cliente;
            ClienteId = cliente.Id;

            if (condutor == null)
                return;

            Condutor = condutor;
            CondutorId = condutor.Id;

            if (categoria == null)
                return;

            Categoria = categoria;
            CategoriaId = categoria.Id;

            if (veiculo == null)
                return;

            Veiculo = veiculo;
            VeiculoId = veiculo.Id;

            if (planoDeCobranca == null)
                return;

            PlanoDeCobranca = planoDeCobranca;
            PlanoDeCobrancaId = planoDeCobranca.Id;

            if (taxa == null)
                return;

            Taxas = taxa;
        }
    }
}
