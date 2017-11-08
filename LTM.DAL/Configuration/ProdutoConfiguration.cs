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
			builder.Property(x => x.Id).HasField("pro_idt_produto");
			builder.Property(x => x.Nome).HasField("pro_des_nome");
			builder.Property(x => x.Descricao).HasField("pro_des_descricao");
			builder.Property(x => x.Especificacoes).HasField("pro_des_especificacoes");
			builder.Property(x => x.ItensEstoque).HasField("pro_num_itens_estoque");
		}
	}
}
