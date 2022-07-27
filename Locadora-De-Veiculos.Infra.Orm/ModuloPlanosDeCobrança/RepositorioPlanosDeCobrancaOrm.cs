using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloPlanosDeCobrança
{
    public class RepositorioPlanosDeCobrancaOrm : RepositorioBaseOrm<PlanoDeCobranca>, IRepositorioPlanoDeCobranca
    {
        private DbSet<PlanoDeCobranca> planosDeCobranca;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioPlanosDeCobrancaOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            planosDeCobranca = dbContext.Set<PlanoDeCobranca>();
            this.dbContext = dbContext;
        }

        public PlanoDeCobranca SelecionarNomeCategoria(string nomeCategoria)
        {
            return planosDeCobranca.SingleOrDefault(x => x.CategoriaDeVeiculos.Nome == nomeCategoria); //Caso haja erro mudar para ToString()
        }
    }
}
