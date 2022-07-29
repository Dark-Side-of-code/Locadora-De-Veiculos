using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloVeiculo
{
    public class RepositorioVeiculoOrm : RepositorioBaseOrm<Veiculo>, IRepositorioVeiculo
    {
        private DbSet<Veiculo> veiculos;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioVeiculoOrm(LocaDoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
            veiculos = dbContext.Set<Veiculo>();
            this.dbContext = dbContext;
        }

        public override List<Veiculo> SelecionarTodos()
        {
            return veiculos.Include(x => x.CategoriaDeVeiculos).ToList();
        }

        public Veiculo SelecionarVeiculoPorPlaca(string placa)
        {
            return veiculos.SingleOrDefault(x => x.Placa == placa);
        }
    }
}
