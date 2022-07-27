using Locadora_De_Veiculos.Dominio.ModuloCategoriaDeVeiculos;
using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloCategoriasDeVeiculos
{
    internal class RepositorioCategoriaDeVeiculosOrm : RepositorioBaseOrm<CategoriaDeVeiculos>, IRepositorioCategoriaDeVeiculos
    {
        private DbSet<CategoriaDeVeiculos> categorias;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioCategoriaDeVeiculosOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            categorias = dbContext.Set<CategoriaDeVeiculos>();
            this.dbContext = dbContext;
        }

        public CategoriaDeVeiculos SelecionarClientePorNome(string nome)
        {
            return categorias.SingleOrDefault(x => x.Nome == nome);
        }
    }
}
