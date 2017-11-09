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
	[Route("api/Usuario")]
	public class UsuarioController : Controller
	{
		private IMapper _mapper;

		public UsuarioController(IMapper mapper)
		{
			_mapper = mapper;
		}

	[HttpGet("Buscar/{login}/{password}")]
		public Entity.API.LoginResponse Buscar(string login, string password)
		{
			return null;
		}

		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Entity.API.UsuarioCriacao usuario)
		{

		}

		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Entity.API.UsuarioAlteracao usuario)
		{

		}
	}
}