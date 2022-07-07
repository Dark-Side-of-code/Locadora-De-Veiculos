using Locadora_De_Veiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos
{
    public class CategoriaDeVeiculos : EntidadeBase<CategoriaDeVeiculos>
    {
        public CategoriaDeVeiculos()
        {
        }

        public CategoriaDeVeiculos(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }

        public override bool Equals(object obj)
        {
            return obj is CategoriaDeVeiculos veiculos &&
                   Nome == veiculos.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Nome);
        }

        public object Clone()
        {
            return MemberwiseClone() as CategoriaDeVeiculos;
        }

        public override string ToString()
        {
            return Nome;
        }
    }
}
