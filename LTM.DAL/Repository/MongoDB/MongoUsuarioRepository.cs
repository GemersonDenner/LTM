using System;
using System.Collections.Generic;
using System.Text;
using LTM.DAL.Context;
using LTM.Entity.DAL;
using MongoDB.Driver;

namespace LTM.DAL.Repository
{
	public class MongoUsuarioRepository : IMongoRepository, IUsuarioRepository
	{
		public MongoUsuarioRepository(MongoContext context) : base(context)
		{
		}

		public void Atualizar(Usuario usuario)
		{
			var filter = Builders<Usuario>.Filter.Where(x => x.Id == usuario.Id);
			var update = Builders<Usuario>.Update
				.Set(x => x.Login, usuario.Login)
				.Set(x => x.Nome, usuario.Nome)
				.Set(x => x.Email, usuario.Email)
				.Set(x => x.Password, usuario.Password);

			_context.GetDatabase().GetCollection<Usuario>(typeof(Usuario).Name)
				.UpdateOne(filter, update);
		}

		public Usuario Buscar(string login, string password)
		{
			return _context.GetDatabase().GetCollection<Usuario>(typeof(Usuario).Name)
				.Find(x => x.Login.Equals(login) && x.Password.Equals(password)).FirstOrDefault();
		}

		public void Cadastrar(Usuario usuario)
		{
			_context.GetDatabase().GetCollection<Usuario>(typeof(Usuario).Name)
				.InsertOne(usuario);
		}
	}
}
