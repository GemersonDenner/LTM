using LTM.DAL.Configuration;
using LTM.Entity.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Context
{
	public class EFContext : DbContext
	{
		public EFContext(DbContextOptions<EFContext> options)
			: base(options)
		{
		}

		public DbSet<Usuario> Usuario { get; set; }

		public DbSet<Produto> Produto { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
			modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
		}
	}
}
