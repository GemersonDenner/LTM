using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LTM.Entity.DAL;
using AutoMapper;

namespace LTM.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Produto")]
    public class ProdutoController : Controller
    {
		private IMapper _mapper;
		public ProdutoController(IMapper mapper)
		{
			_mapper = mapper;
		}

		[HttpGet("BuscarTodos/")]
		public IEnumerable<Entity.API.Produto> BuscarTodos()
		{
			return null;
		}

		[HttpGet("BuscarTodos/{idProduto}")]
		public Entity.API.Produto Buscar(Guid idProduto)
		{
			return null;
		}

		[HttpDelete("Deletar/{idProduto}")]
		public void Deletar(Guid idProduto)
		{

		}

		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Entity.API.Produto produto)
		{

		}
		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Entity.API.ProdutoAdicionar produto)
		{

		}
	}
}