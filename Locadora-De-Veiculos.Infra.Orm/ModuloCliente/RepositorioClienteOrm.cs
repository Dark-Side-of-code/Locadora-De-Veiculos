using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloCliente
{
    public class RepositorioClienteOrm : RepositorioBaseOrm<Cliente>,IRepositorioCliente
    {
        private DbSet<Cliente> clientes;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioClienteOrm(LocaDoraDeVeiculosDbContext dbContext)
        {
            clientes = dbContext.Set<Cliente>();
            this.dbContext = dbContext;
        }

        public Cliente SelecionarClientePorCPF_CNPJ(string cpf_cnpj)
        {
            return clientes.SingleOrDefault(x => x.CPF_CNPJ == cpf_cnpj);
        }

        public Cliente SelecionarClientePorNome(string nome)
        {
            return clientes.SingleOrDefault(x => x.Nome == nome);
        }
    }
}
