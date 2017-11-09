using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.Entity.API
{
    public class ProdutoAdicionar
    {
		public string Nome { get; set; }

		public string Descricao { get; set; }

		public string Especificacoes { get; set; }

		public int ItensEstoque { get; set; }
	}
}
