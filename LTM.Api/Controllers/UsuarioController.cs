using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LTM.Entity.DAL;
using AutoMapper;
using LTM.DAL.Repository;

namespace LTM.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Usuario")]
	public class UsuarioController : Controller
	{
		private IMapper _mapper;
		private IUsuarioRepository _UsuarioRepository;

		public UsuarioController(IUsuarioRepository iUsuarioRepository, IMapper mapper)
		{
			_UsuarioRepository = iUsuarioRepository;
			_mapper = mapper;
		}

	[HttpGet("Buscar/{login}/{password}")]
		public Entity.API.LoginResponse Buscar(string login, string password)
		{
			var usr = _UsuarioRepository.Buscar(login, password);
			return _mapper.Map<Entity.API.LoginResponse>(usr);
		}

		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Entity.API.UsuarioCriacao usuario)
		{
			var usrDal = _mapper.Map<Entity.DAL.Usuario>(usuario);
			_UsuarioRepository.Cadastrar(usrDal);

		}

		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Entity.API.UsuarioAlteracao usuario)
		{
			var usrDal = _mapper.Map<Entity.DAL.Usuario>(usuario);
			_UsuarioRepository.Atualizar(usrDal);

		}
	}
}