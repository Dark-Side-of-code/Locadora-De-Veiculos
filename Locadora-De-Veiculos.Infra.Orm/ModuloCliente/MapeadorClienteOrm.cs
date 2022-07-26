using Locadora_De_Veiculos.Dominio.ModuloCliente;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloCliente
{
    public class MapeadorClienteOrm : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("TbCliente");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(300)");
            builder.Property(x => x.CPF_CNPJ).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Tipo_Cliente).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Telefone).IsRequired().HasColumnType("varchar(20)");
        }
    }
}
