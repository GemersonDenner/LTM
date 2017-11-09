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
	[Route("api/Usuario")]
	public class UsuarioController : Controller
	{
		[HttpGet("Buscar/{login}/{password}")]
		public Usuario Buscar(string login, string password)
		{
			return null;
		}

		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Usuario usuario)
		{

		}

		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Usuario usuario)
		{

		}
	}
}