using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LTM.Entity.DAL;
using AutoMapper;
using LTM.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using LTM.JWT;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace LTM.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Usuario")]
	public class UsuarioController : Controller
	{
		private IMapper _mapper;
		private IUsuarioRepository _UsuarioRepository;
		private readonly IConfiguration _configuration;

		public UsuarioController(IUsuarioRepository iUsuarioRepository, IMapper mapper, IConfiguration configuration)
		{
			_UsuarioRepository = iUsuarioRepository;
			_mapper = mapper;
			_configuration = configuration;
		}

		[AllowAnonymous]
		[HttpGet("Buscar/{login}/{password}")]
		public Entity.API.LoginResponse Buscar(string login, string password)
		{
			var usr = _UsuarioRepository.Buscar(login, password);

			if (usr != null && !string.IsNullOrEmpty(usr.Login))
			{
				IConfigurationSection jwtAppSettingOptions = _configuration.GetSection("JwtIssuerOptions");
				var secretKey = jwtAppSettingOptions["SecretKey"];
				var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

				var token = new JwtTokenBuilder()
					.AddSecurityKey(JwtSecurityKey.Create(signingKey.ToString()))
					.AddIssuer(jwtAppSettingOptions["Issuer"])
					.AddAudience(jwtAppSettingOptions["Audience"])
					.AddExpiry(1)
					.AddClaim(ClaimTypes.NameIdentifier, usr.Nome)
					.AddClaim(ClaimTypes.Name, usr.Login)
					.AddClaim(ClaimTypes.Role, "USUARIO")
					.Build();

				var resultMapped = _mapper.Map<Entity.API.LoginResponse>(usr);
				resultMapped.ChaveJwt = token.Value;

				return resultMapped;
			}
			else return new Entity.API.LoginResponse();
		}

		[AllowAnonymous]
		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Entity.API.UsuarioCriacao usuario)
		{
			var usrDal = _mapper.Map<Entity.DAL.Usuario>(usuario);
			_UsuarioRepository.Cadastrar(usrDal);

		}

		[Authorize(Roles = "USUARIO")]
		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Entity.API.UsuarioAlteracao usuario)
		{
			var usrDal = _mapper.Map<Entity.DAL.Usuario>(usuario);
			_UsuarioRepository.Atualizar(usrDal);

		}
	}
}