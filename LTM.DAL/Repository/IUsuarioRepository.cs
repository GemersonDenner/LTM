using System;
using System.Collections.Generic;
using System.Text;
using LTM.DAL.Context;
using LTM.Entity.DAL;

namespace LTM.DAL.Repository
{
	public interface IUsuarioRepository
	{
		Usuario Buscar(string login, string password);

		void Cadastrar(Usuario usuario);

		void Atualizar(Usuario usuario);
	}
}
