using LTM.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("tb_usuario");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasField("usr_idt_produto");
			builder.Property(x => x.Nome).HasField("usr_des_nome");
			builder.Property(x => x.Email).HasField("usr_des_email");
			builder.Property(x => x.Login).HasField("usr_des_login");
			builder.Property(x => x.Password).HasField("usr_des_password");
		}
	}
}
