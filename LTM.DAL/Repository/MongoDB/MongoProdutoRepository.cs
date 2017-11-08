using System;
using System.Collections.Generic;
using System.Text;
using LTM.DAL.Context;
using LTM.Entity.DAL;
using MongoDB.Driver;

namespace LTM.DAL.Repository
{
	public class MongoProdutoRepository : IMongoRepository, IProdutoRepository
	{
		public MongoProdutoRepository(MongoContext context) : base(context)
		{
		}

		public void Atualizar(Produto produto)
		{
			var filter = Builders<Produto>.Filter.Where(x => x.Id == produto.Id);
			var update = Builders<Produto>.Update
				.Set(x => x.Descricao, produto.Descricao)
				.Set(x => x.Especificacoes, produto.Especificacoes)
				.Set(x => x.ItensEstoque, produto.ItensEstoque)
				.Set(x => x.Nome, produto.Nome);

			_context.GetDatabase().GetCollection<Produto>(typeof(Produto).Name)
				.UpdateOne(filter, update);
		}

		public Produto Buscar(Guid idProduto)
		{
			return _context.GetDatabase().GetCollection<Produto>(typeof(Produto).Name)
				.Find(x => x.Id == idProduto).FirstOrDefault();
		}

		public IEnumerable<Produto> BuscarTodos()
		{
			return _context.GetDatabase().GetCollection<Produto>(typeof(Produto).Name)
				.Find(x => true).ToList();
		}

		public void Cadastrar(Produto produto)
		{
			_context.GetDatabase().GetCollection<Produto>(typeof(Produto).Name)
				.InsertOne(produto);
		}

		public void Deletar(Guid idProduto)
		{
			var filter = Builders<Produto>.Filter.Where(x => x.Id == idProduto);
			_context.GetDatabase().GetCollection<Produto>(typeof(Produto).Name)
				.DeleteOne(filter);
		}
	}
}
