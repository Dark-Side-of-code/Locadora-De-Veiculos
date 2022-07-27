using Locadora_De_Veiculos.Dominio.ModuloGrupoDeVeiculos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloCategoriasDeVeiculos
{
    public class MapeadorCategoriaVeiculoOrm : IEntityTypeConfiguration<CategoriaDeVeiculos>
    {
        public void Configure(EntityTypeBuilder<CategoriaDeVeiculos> builder)
        {
            builder.ToTable("TbCategoriaVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
        }
    }
}
