using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloTaxas
{
    public class Taxa : EntidadeBase<Taxa>
    {
        public Taxa()
        {
        }

        public Taxa(string nome, string descricao, string tipoDeCobranca, double valor)
        {
            Nome = nome;
            Descricao = descricao;
            TipoDeCobraca = tipoDeCobranca;
            Valor = valor;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string TipoDeCobraca { get; set; }
        public double Valor { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Taxa taxa &&
                   Id == taxa.Id &&
                   Nome == taxa.Nome &&
                   Descricao == taxa.Descricao &&
                   TipoDeCobraca == taxa.TipoDeCobraca &&
                   Valor == taxa.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, Descricao, TipoDeCobraca, Valor);
        }

        public object Clone()
        {
            return MemberwiseClone() as Taxa;
        }
    }
}
