using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LTM.Entity.DAL;

namespace LTM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    public class ProdutoController : Controller
    {
		[HttpGet("BuscarTodos/")]
		public IEnumerable<Produto> BuscarTodos()
		{
			return null;
		}

		[HttpGet("BuscarTodos/{idProduto}")]
		public Produto Buscar(Guid idProduto)
		{
			return null;
		}

		[HttpDelete("Deletar/{idProduto}")]
		public void Deletar(Guid idProduto)
		{

		}

		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Produto produto)
		{

		}
		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Produto produto)
		{

		}
	}
}