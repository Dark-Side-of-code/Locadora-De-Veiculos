using Locadora_De_Veiculos.Dominio.ModuloVeiculo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloVeiculo
{
    public class MapeadorVeiculoOrm : IEntityTypeConfiguration<Veiculo>
    {
        public void Configure(EntityTypeBuilder<Veiculo> builder)
        {
            builder.ToTable("TbVeiculo");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Modelo).IsRequired().HasColumnType("varchar(300)");
            builder.Property(x => x.Placa).IsRequired().HasColumnType("varchar(7)");
            builder.Property(x => x.Marca).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Cor).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Tipo_combustivel).IsRequired().HasColumnType("varchar(100)");
            builder.Property(x => x.Capacidade_tanque).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.Ano).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.Km_total).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.Foto).IsRequired().HasColumnType("varbinary(MAX)");
            builder.Property(x => x.StatusVeiculo).IsRequired().HasColumnType("int");
            builder.HasOne(x => x.CategoriaDeVeiculos);
        }
    }
}
