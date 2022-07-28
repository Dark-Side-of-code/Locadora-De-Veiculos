using Locadora_De_Veiculos.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.Compartilhado
{
    public abstract class RepositorioBaseOrm<T> : IRepositorio<T>
        where T : EntidadeBase<T>
    {
        private DbSet<T> entidades;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        protected RepositorioBaseOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            entidades = dbContext.Set<T>();
            this.dbContext = dbContext;
        }

        public virtual void Editar(T registro)
        {
            entidades.Update(registro);
        }

        public virtual void Excluir(T registro)
        {
            entidades.Remove(registro);
        }

        public virtual void Inserir(T novoRegistro)
        {
            entidades.Add(novoRegistro);
        }

        public virtual T SelecionarPorNumero(Guid numero)
        {
            return entidades.SingleOrDefault(x => x.Id == numero);
        }

        public virtual List<T> SelecionarTodos()
        {
            return entidades.ToList();
        }
    }
}
