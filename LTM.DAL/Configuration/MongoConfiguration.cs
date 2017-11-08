using LTM.Entity.DAL;
using MongoDB.Bson.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace LTM.DAL.Configuration
{
    public static class MongoConfiguration
    {
		public static void EfetuarConfiguracao()
		{
			BsonClassMap.RegisterClassMap<Usuario>(x =>
			{
				x.MapProperty(p => p.Id).SetElementName("id");
				x.MapProperty(p => p.Login).SetElementName("login");
				x.MapProperty(p => p.Nome).SetElementName("nome");
				x.MapProperty(p => p.Password).SetElementName("password");
				x.MapProperty(p => p.Email).SetElementName("email");
			});

			BsonClassMap.RegisterClassMap<Produto>(x =>
			{
				x.MapProperty(p => p.Id).SetElementName("id");
				x.MapProperty(p => p.Descricao).SetElementName("descricao");
				x.MapProperty(p => p.Nome).SetElementName("nome");
				x.MapProperty(p => p.Especificacoes).SetElementName("especificacoes");
				x.MapProperty(p => p.ItensEstoque).SetElementName("estoque");
			});
		}
	}
}
