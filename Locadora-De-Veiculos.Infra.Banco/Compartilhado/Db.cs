﻿using System.Data.SqlClient;

namespace Locadora_De_Veiculos.Infra.Banco.Compartilhado
{
    public static class Db
    {
        private static string enderecoBanco =
            @"";

        public static void ExecutarSql(string sql)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}
