using System;
using System.Collections.Generic;
using System.Text;
using LTM.DAL.Context;
using LTM.Entity.DAL;
using System.Linq;

namespace LTM.DAL.Repository
{
	public class EFUsuarioRepository : IEfRepository, IUsuarioRepository
	{
		public EFUsuarioRepository(EFContext context) : base(context)
		{
		}

		public void Atualizar(Usuario usuario)
		{
			_context.Usuario.Update(usuario);
			_context.SaveChanges();
		}

		public Usuario Buscar(string login, string password)
		{
			return _context.Usuario.Where(x => x.Login.Equals(login) && x.Password.Equals(password)).FirstOrDefault();
		}

		public void Cadastrar(Usuario usuario)
		{
			_context.Usuario.Add(usuario);
			_context.SaveChanges();
		}
	}
}
