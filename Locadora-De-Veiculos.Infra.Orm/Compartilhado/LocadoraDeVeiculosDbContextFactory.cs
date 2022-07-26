using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Locadora_De_Veiculos.Infra.Orm.Compartilhado
{
    internal class LocadoraDeVeiculosDbContextFactory : IDesignTimeDbContextFactory<LocaDoraDeVeiculosDbContext>
    {
        public LocaDoraDeVeiculosDbContext CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("ConfiguracaoAplicacao.json")
             .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            return new LocaDoraDeVeiculosDbContext(connectionString);
        }
    }
}
