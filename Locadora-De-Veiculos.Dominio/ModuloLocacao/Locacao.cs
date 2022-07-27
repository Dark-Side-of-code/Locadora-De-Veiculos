using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloLocacao
{
    public class Locacao : EntidadeBase<Locacao>
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public Condutor Condutor { get; set; }
        public CategoriaDeVeiculos Categoria { get; set; }
        public Veiculo Veiculo { get; set; }
        public PlanoDeCobranca PlanoDeCobranca { get; set; }
        public double valorEstimado { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinalPrevista { get; set; }

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
    }
}
