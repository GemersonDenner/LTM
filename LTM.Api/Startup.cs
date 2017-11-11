using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using LTM.Api.Mapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Newtonsoft.Json.Serialization;
using LTM.JWT;
using Microsoft.EntityFrameworkCore;

namespace LTM.Api
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc().AddJsonOptions(o =>
			{
				o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info { Title = "API LTM" });
			});

			var config = new AutoMapper.MapperConfiguration(
				c =>
				{
					c.AddProfile(new ConfigMapper());
				});

			var mapper = config.CreateMapper();
			services.AddSingleton(mapper);


			//Se quiser rodar com MongoDB
			////**********************************////
			var contextMongo = new LTM.DAL.Context.MongoContext(Configuration.GetConnectionString("DefaultConnectionMongo"), Configuration.GetSection("DataBase").GetValue<string>("DbName"));
			var repProduto = new DAL.Repository.MongoProdutoRepository(contextMongo);
			services.AddSingleton<DAL.Repository.IProdutoRepository>(repProduto);
			var repUsuario = new DAL.Repository.MongoUsuarioRepository(contextMongo);
			services.AddSingleton<DAL.Repository.IUsuarioRepository>(repUsuario);


			//Se quiser rodar com SQL
			////**********************************////

			//var opt = SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder<LTM.DAL.Context.EFContext>(), Configuration.GetConnectionString("DefaultConnectionSql")).Options;
			//var cont = new LTM.DAL.Context.EFContext(opt);
			//var repProduto = new DAL.Repository.EFProdutoRepository(cont);
			//services.AddSingleton<DAL.Repository.IProdutoRepository>(repProduto);
			//var repUsuario = new DAL.Repository.EFUsuarioRepository(cont);
			//services.AddSingleton<DAL.Repository.IUsuarioRepository>(repUsuario);




			IConfigurationSection jwtAppSettingOptions = Configuration.GetSection("JwtIssuerOptions");
			var secretKey = jwtAppSettingOptions["SecretKey"];
			var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
					.AddJwtBearer(options =>
					{
						options
							.TokenValidationParameters
								= new TokenValidationParameters
								{
									ValidateIssuer = true,
									ValidateAudience = true,
									ValidateLifetime = true,
									RequireExpirationTime = true,
									ValidateIssuerSigningKey = true,
									LifetimeValidator = JwtExpireValidator.LifetimeValidator,
									ValidIssuer = jwtAppSettingOptions["Issuer"],
									ValidAudience = jwtAppSettingOptions["Audience"],
									IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(signingKey.ToString()))
								};
					});

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			app.UseAuthentication();
			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API LTM v1");
			});
		}
	}
}
