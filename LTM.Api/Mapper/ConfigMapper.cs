using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LTM.Entity.DAL;
using LTM.Entity.API;

namespace LTM.Api.Mapper
{
    public class ConfigMapper : AutoMapper.Profile
	{
		public ConfigMapper()
		{
			CreateMap<Entity.DAL.Usuario, Entity.API.LoginResponse>();
			CreateMap<Entity.DAL.Produto, Entity.API.Produto>();
			CreateMap<Entity.API.ProdutoAdicionar, Entity.DAL.Produto>();
			CreateMap<Entity.API.UsuarioCriacao, Entity.DAL.Usuario>();
			CreateMap<Entity.API.UsuarioAlteracao, Entity.DAL.Usuario>();
		}
	}
}
