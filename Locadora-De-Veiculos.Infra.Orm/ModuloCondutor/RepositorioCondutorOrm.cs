using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloCondutor
{
    public class RepositorioCondutorOrm : RepositorioBaseOrm<Condutor>, IRepositorioCondutor
    {
        private DbSet<Condutor> condutores;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioCondutorOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            condutores = dbContext.Set<Condutor>();
            this.dbContext = dbContext;
        }

        public Condutor SelecionarCondutorPorCNH(string cnh)
        {
            return condutores.SingleOrDefault(x => x.CNH == cnh);
        }

        public Condutor SelecionarCondutorPorCPF(string cpf_cnpj)
        {
            return condutores.SingleOrDefault(x => x.CPF == cpf_cnpj);
        }
    }
}
