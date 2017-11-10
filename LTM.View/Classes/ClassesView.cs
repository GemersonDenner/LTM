using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LTM.View.Classes
{
	public class Logar
	{
		public string Login { get; set; }
		public string Senha { get; set; }
	}

	public class Cadastrar
	{
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }
	}

	public class Produto
	{
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string Especificacao { get; set; }
		public int QuantidadeEstoque { get; set; }
	}
}
