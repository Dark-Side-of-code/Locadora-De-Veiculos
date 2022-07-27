using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloTaxas
{
    public class RepositorioTaxaOrm : RepositorioBaseOrm<Taxa>, IRepositorioTaxa
    {
        private DbSet<Taxa> taxas;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioTaxaOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            taxas = dbContext.Set<Taxa>();
            this.dbContext = dbContext;
        }

        public Taxa SelecionarTaxaPorNome(string nome)
        {
            return taxas.SingleOrDefault(x => x.Nome == nome);
        }
    }
}
