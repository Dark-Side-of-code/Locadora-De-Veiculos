using Locadora_De_Veiculos.Dominio.ModuloCondutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloCondutor
{
    public class MapeadorCondutorOrm : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.ToTable("TbCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(300)");
            builder.Property(x => x.CPF).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.CNH).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Validade_CNH).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Telefone).IsRequired().HasColumnType("varchar(20)");
            builder.Property(x => x.Edereco).IsRequired().HasColumnType("varchar(300)");
            builder.HasOne(x => x.Cliente);
        }
    }
}
