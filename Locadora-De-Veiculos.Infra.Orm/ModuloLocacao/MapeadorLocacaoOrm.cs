using Locadora_De_Veiculos.Dominio.ModuloLocacao;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloLocacao
{
    public class MapeadorLocacaoOrm : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.ToTable("TbLocacao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.HasOne(x => x.Funcionario);
            builder.HasOne(x => x.Cliente);
            builder.HasOne(x => x.Condutor).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Categoria);
            builder.HasOne(x => x.Veiculo).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PlanoDeCobranca).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.Taxas);
            builder.Property(x => x.valorEstimado).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.NomeDoPlano).IsRequired().HasColumnType("varchar(300)");
            builder.Property(x => x.Status).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.DataInicio).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.DataFinalPrevista).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.TipoDoPlano).IsRequired().HasColumnType("varchar(50)");

            //Atributos Relacionados A Devolucao

            builder.Property(x => x. DataFinalReal).HasColumnType("datetime");
            builder.Property(x => x.QuilometragemDoVeiculo).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.ValorGasolina).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.NivelDoTanque).HasColumnType("decimal(18, 2)");
            builder.Property(x => x.ValorTotal).HasColumnType("decimal(18, 2)");
            builder.HasMany(x => x.TaxaAdicional);
        }
    }
}
