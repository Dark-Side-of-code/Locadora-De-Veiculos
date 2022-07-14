using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloVeiculo
{
    public class MapeadorVeiculo : MapeadorBase<Veiculo>
    {
        public override void ConfigurarParametros(Veiculo registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("MODELO", registro.Modelo);
            comando.Parameters.AddWithValue("PLACA", registro.Placa);
            comando.Parameters.AddWithValue("MARCA", registro.Marca);
            comando.Parameters.AddWithValue("COR", registro.Cor);
            comando.Parameters.AddWithValue("TIPO_COMBUSTIVEL", registro.Tipo_combustivel);
            comando.Parameters.AddWithValue("CAPACIDADE_TANQUE", registro.Capacidade_tanque);
            comando.Parameters.AddWithValue("ANO", registro.Ano);
            comando.Parameters.AddWithValue("KM_TOTAL", registro.Km_total);
            comando.Parameters.AddWithValue("FOTO", registro.Foto);
            comando.Parameters.AddWithValue("CATEGORIA_ID", registro.CategoriaDeVeiculos.Id);
        }

        public override Veiculo ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var modelo = Convert.ToString(leitorRegistro["MODELO"]);
            var placa = Convert.ToString(leitorRegistro["PLACA"]);
            var marca = Convert.ToString(leitorRegistro["MARCA"]);
            var cor = Convert.ToString(leitorRegistro["COR"]);
            var tipo = Convert.ToString(leitorRegistro["TIPO_COMBUSTIVEL"]);
            var capacidade = Convert.ToDouble(leitorRegistro["CAPACIDADE_TANQUE"]);
            var ano = Convert.ToDateTime(leitorRegistro["ANO"]);
            var km_total = Convert.ToDouble(leitorRegistro["KM_TOTAL"]);
            var foto = (byte[])leitorRegistro["FOTO"];

            var categoria_id = Guid.Parse(leitorRegistro["CATEGORIA_ID"].ToString());
            var categoria_nome = Convert.ToString(leitorRegistro["CATEGORIA_NOME"]);

            var veiculo = new Veiculo
            {
                Id = id,
                Modelo = modelo,
                Placa = placa,
                Marca = marca,
                Cor = cor,
                Tipo_combustivel = tipo,
                Capacidade_tanque = capacidade,
                Ano = ano,
                Km_total = km_total,
                Foto = foto
            };

            var categoriaVeiculo = new CategoriaDeVeiculos
            {
                Id = categoria_id,
                Nome = categoria_nome
            };

            veiculo.ConfigurarCategoria(categoriaVeiculo);

            return veiculo;
        }
    }
}
