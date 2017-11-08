using LTM.DAL.Context;
using LTM.Entity.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Repository
{
	public interface IProdutoRepository
	{
		IEnumerable<Produto> BuscarTodos();

		Produto Buscar(Guid idProduto);

		void Deletar(Guid idProduto);

		void Atualizar(Produto produto);

		void Cadastrar(Produto produto);
	}
}
