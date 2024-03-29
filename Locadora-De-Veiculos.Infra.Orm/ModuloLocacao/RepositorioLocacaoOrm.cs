﻿using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Locadora_De_Veiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloLocacao
{
    public class RepositorioLocacaoOrm : RepositorioBaseOrm<Locacao>, IRepositorioLocacao
    {
        private DbSet<Locacao> locacoes;
        private readonly LocaDoraDeVeiculosDbContext dbContext;

        public RepositorioLocacaoOrm(LocaDoraDeVeiculosDbContext dbContext) : base(dbContext)
        {
            locacoes = dbContext.Set<Locacao>();
            this.dbContext = dbContext;
        }

        public Locacao SelecionarLocacaoPorGuid(Guid id)
        {
            return locacoes.SingleOrDefault(x => x.Id == id);
        }

        public override List<Locacao> SelecionarTodos()
        {
            return locacoes
                .Include(x => x.Funcionario)
                .Include(x => x.Cliente)
                .Include(x => x.Condutor)
                .Include(x => x.Categoria)
                .Include(x => x.Veiculo)
                .Include(x => x.PlanoDeCobranca)
                .Include(x => x.Taxas)
                .ToList();
        }


    }
}
