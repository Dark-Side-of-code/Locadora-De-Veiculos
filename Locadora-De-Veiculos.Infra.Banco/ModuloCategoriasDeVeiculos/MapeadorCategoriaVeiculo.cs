using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloCategoriasDeVeiculos
{
    public class MapeadorCategoriaVeiculo : MapeadorBase<CategoriaDeVeiculos>
    {
        public override void ConfigurarParametros(CategoriaDeVeiculos registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
        }

        public override CategoriaDeVeiculos ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Guid.Parse(leitorRegistro["ID"].ToString());
            var nome = Convert.ToString(leitorRegistro["NOME"]);

            CategoriaDeVeiculos categoriaDeVeiculos = new CategoriaDeVeiculos();
            categoriaDeVeiculos.Id = id;
            categoriaDeVeiculos.Nome = nome;

            return categoriaDeVeiculos;
        }
    }
}
