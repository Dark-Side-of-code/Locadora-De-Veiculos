using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloFuncionario
{
    public class RepositorioFuncionarioOrm : RepositorioBaseOrm<Funcionario>, IRepositorioFuncionario
    {
        private DbSet<Funcionario> funcionarios;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioFuncionarioOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            funcionarios = dbContext.Set<Funcionario>(); 
            this.dbContext = dbContext;
        }

        public Funcionario SelecionarFuncionarioPorNome(string nome)
        {
            return funcionarios.SingleOrDefault(x => x.Nome == nome);
        }

        public Funcionario SelecionarFuncionarioPorUsuario(string usuario)
        {
            return funcionarios.SingleOrDefault(x => x.TipoFuncionario == usuario);
        }
    }
}
