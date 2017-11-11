using LTM.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Configuration
{
	public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder.ToTable("tb_produto");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).HasColumnName("pro_idt_produto");
			builder.Property(x => x.Nome).HasColumnName("pro_des_nome");
			builder.Property(x => x.Descricao).HasColumnName("pro_des_descricao");
			builder.Property(x => x.Especificacoes).HasColumnName("pro_des_especificacoes");
			builder.Property(x => x.ItensEstoque).HasColumnName("pro_num_itens_estoque");
		}
	}
}
