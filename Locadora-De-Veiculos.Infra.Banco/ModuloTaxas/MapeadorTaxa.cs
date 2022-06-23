using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Banco.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Banco.ModuloTaxas
{
    public class MapeadorTaxa : MapeadorBase<Taxa>
    {
        public override void ConfigurarParametros(Taxa registro, SqlCommand comando)
        {
            comando.Parameters.AddWithValue("ID", registro.Id);
            comando.Parameters.AddWithValue("NOME", registro.Nome);
            comando.Parameters.AddWithValue("DESCRICAO", registro.Descricao);
            comando.Parameters.AddWithValue("VALOR", registro.Valor);
            comando.Parameters.AddWithValue("DIARIO_FIXO", registro.TipoDeCobraca);
        }

        public override Taxa ConverterRegistro(SqlDataReader leitorRegistro)
        {
            var id = Convert.ToInt32(leitorRegistro["ID"]);
            var nome = Convert.ToString(leitorRegistro["NOME"]);
            var descricao = Convert.ToString(leitorRegistro["DESCRICAO"]);
            var valor = Convert.ToString(leitorRegistro["VALOR"]);
            var tipo = Convert.ToString(leitorRegistro["DIARIO_FIXO"]);

            Taxa taxa = new Taxa();
            taxa.Id = id;
            taxa.Nome = nome;
            taxa.Descricao = descricao;
            taxa.Valor = Convert.ToDouble(valor);
            taxa.TipoDeCobraca = tipo;

            return taxa;
        }
    }
}
