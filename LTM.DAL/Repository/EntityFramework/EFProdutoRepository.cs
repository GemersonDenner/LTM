using System;
using System.Collections.Generic;
using System.Text;
using LTM.DAL.Context;
using LTM.Entity.DAL;
using System.Linq;

namespace LTM.DAL.Repository
{
	public class EFProdutoRepository : IEfRepository, IProdutoRepository
	{
		public EFProdutoRepository(EFContext context) : base(context)
		{
		}

		public void Atualizar(Produto produto)
		{
			_context.Produto.Update(produto);
			_context.SaveChanges();
		}

		public Produto Buscar(Guid idProduto)
		{
			return _context.Produto.Where(x => x.Id.Equals(idProduto)).FirstOrDefault();
		}

		public IEnumerable<Produto> BuscarTodos()
		{
			return _context.Produto.ToList();
		}

		public void Cadastrar(Produto produto)
		{
			_context.Produto.Add(produto);
			_context.SaveChanges();
		}

		public void Deletar(Guid idProduto)
		{
			var produto = Buscar(idProduto);
			_context.Produto.Remove(produto);
			_context.SaveChanges();
		}
	}
}
