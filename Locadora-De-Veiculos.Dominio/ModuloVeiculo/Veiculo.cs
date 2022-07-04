using Locadora_De_Veiculos.Dominio.Compartilhado;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Dominio.ModuloVeiculo
{
    public class Veiculo : EntidadeBase<Veiculo>
    {
        public Veiculo()
        {

        }

        public Veiculo(string modelo, string placa, string marca, string cor, string tipo_combustivel, double capacidade_tanque, DateTime ano, double km_total, CategoriaDeVeiculos categoriaDeVeiculos)
        {
            Modelo = modelo;
            Placa = placa;
            Marca = marca;
            Cor = cor;
            Tipo_combustivel = tipo_combustivel;
            Capacidade_tanque = capacidade_tanque;
            Ano = ano;
            Km_total = km_total;
            CategoriaDeVeiculos = categoriaDeVeiculos;
        }

        public Veiculo(string modelo, string placa, string marca, string cor, string tipo_combustivel, double capacidade_tanque, DateTime ano, double km_total, byte[] foto, CategoriaDeVeiculos categoriaDeVeiculos)
        {
            Modelo = modelo;
            Placa = placa;
            Marca = marca;
            Cor = cor;
            Tipo_combustivel = tipo_combustivel;
            Capacidade_tanque = capacidade_tanque;
            Ano = ano;
            Km_total = km_total;
            Foto = foto;
            CategoriaDeVeiculos = categoriaDeVeiculos;
        }

        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Tipo_combustivel { get; set; }
        public double Capacidade_tanque { get; set; }
        public DateTime Ano { get; set; }
        public double Km_total { get; set; }
        public byte[] Foto { get; set; }
        public CategoriaDeVeiculos CategoriaDeVeiculos { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Veiculo veiculo &&
                   Id == veiculo.Id &&
                   Modelo == veiculo.Modelo &&
                   Placa == veiculo.Placa &&
                   Marca == veiculo.Marca &&
                   Cor == veiculo.Cor &&
                   Tipo_combustivel == veiculo.Tipo_combustivel &&
                   Capacidade_tanque == veiculo.Capacidade_tanque &&
                   Ano == veiculo.Ano &&
                   Km_total == veiculo.Km_total &&
                   //EqualityComparer<byte[]>.Default.Equals(Foto, veiculo.Foto) &&
                   EqualityComparer<CategoriaDeVeiculos>.Default.Equals(CategoriaDeVeiculos, veiculo.CategoriaDeVeiculos);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(Id);
            hash.Add(Modelo);
            hash.Add(Placa);
            hash.Add(Marca);
            hash.Add(Cor);
            hash.Add(Tipo_combustivel);
            hash.Add(Capacidade_tanque);
            hash.Add(Ano);
            hash.Add(Km_total);
            //hash.Add(Foto);
            hash.Add(CategoriaDeVeiculos);
            return hash.ToHashCode();
        }

        public object Clone()
        {
            return MemberwiseClone() as Veiculo;
        }

        public void ConfigurarCategoria(CategoriaDeVeiculos categoria)
        {
            if (categoria == null)
                return;

            CategoriaDeVeiculos = categoria;
        }
    }
}
