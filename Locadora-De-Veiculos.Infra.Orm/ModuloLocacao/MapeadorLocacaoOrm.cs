using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TbCondutor");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Funcionario);
            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Condutor);
            builder.HasOne(x => x.Categoria);
            builder.HasOne(x => x.Veiculo);
            builder.HasOne(x => x.PlanoDeCobranca);
            builder.HasOne(x => x.Taxa);
            builder.Property(x => x.valorEstimado).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.DataInicio).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.DataFinalPrevista).IsRequired().HasColumnType("datetime");
        }
    }
}
