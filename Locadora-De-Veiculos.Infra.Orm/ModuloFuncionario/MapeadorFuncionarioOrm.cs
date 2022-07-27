using Locadora_De_Veiculos.Dominio.ModuloFuncionario;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora_De_Veiculos.Infra.Orm.ModuloFuncionario
{
    public class MapeadorFuncionarioOrm : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("TbCliente");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).IsRequired().HasColumnType("varchar(200)");
            builder.Property(x => x.Login).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Senha).IsRequired().HasColumnType("varchar(50)");
            builder.Property(x => x.Salario).IsRequired().HasColumnType("decimal(18, 2)");
            builder.Property(x => x.DataAdmissao).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.TipoFuncionario).IsRequired().HasColumnType("varchar(60)");
        }
    }
}
