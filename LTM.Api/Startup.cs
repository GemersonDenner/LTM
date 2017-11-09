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
			services.AddMvc();

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

			var context = new LTM.DAL.Context.MongoContext(Configuration.GetConnectionString("DefaultConnection"), Configuration.GetSection("DataBase").GetValue<string>("DbName"));
			var rep = new DAL.Repository.MongoProdutoRepository(context);
			services.AddSingleton<DAL.Repository.IProdutoRepository>(rep);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API LTM v1");
			});
		}
	}
}
