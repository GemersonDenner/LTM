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
			builder.Property(x => x.Id).HasColumnName("usr_idt_usuario");
			builder.Property(x => x.Nome).HasColumnName("usr_des_nome");
			builder.Property(x => x.Email).HasColumnName("usr_des_email");
			builder.Property(x => x.Login).HasColumnName("usr_des_login");
			builder.Property(x => x.Password).HasColumnName("usr_des_password");
		}
	}
}
