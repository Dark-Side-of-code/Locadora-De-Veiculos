using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Locadora_De_Veiculos.Infra.Banco.Compartilhado
{
    public static class Db
    {

        public static void ExecutarSql(string sql)
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfiguracaoAplicacao.json")
                .Build();

            var enderecoBanco = configuracao.GetConnectionString("SqlServer");

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comando = new SqlCommand(sql, conexaoComBanco);

            conexaoComBanco.Open();
            comando.ExecuteNonQuery();
            conexaoComBanco.Close();
        }
    }
}
