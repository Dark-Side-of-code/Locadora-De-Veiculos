using Locadora_De_Veiculos.Dominio.ModuloPlanosDeCobranca;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloPlanosDeCobrança
{
    public class MapeadorPlanoDeCobrancaOrm : IEntityTypeConfiguration<PlanoDeCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoDeCobranca> builder)
        {
            builder.ToTable("TbPlanoCobranca");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.PlanoDiario_ValorDiario).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PlanoDiario_ValorPorKM).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PlanoKM_Livre_ValorDiario).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PlanoKM_controlado_LimiteDeQuilometragem).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PlanoKM_controlado_ValorDiario).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.PlanoKM_controlado_ValorPorKM).IsRequired().HasColumnType("decimal(18, 2)");
            builder.HasOne(x => x.CategoriaDeVeiculos);
        }
    }
}
