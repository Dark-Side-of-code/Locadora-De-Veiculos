using Locadora_De_Veiculos.Dominio.ModuloTaxas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloTaxas
{
    public class MapeadorTaxaOrm : IEntityTypeConfiguration<Taxa>
    {
        public void Configure(EntityTypeBuilder<Taxa> builder)
        {
            builder.ToTable("TbTaxas");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Descricao).IsRequired().HasColumnType("varchar(500)");
            builder.Property(x => x.TipoDeCobraca).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Valor).IsRequired().HasColumnType("decimal(18, 2)");
        }
    }
}
