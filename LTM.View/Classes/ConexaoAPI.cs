using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LTM.View.Classes
{
	public class ConexaoAPI
	{
		private string enderecoBaseAPI;
		public ConexaoAPI(string apiBase)
		{
			enderecoBaseAPI = apiBase;
		}

		public Entity.API.LoginResponse Login(Entity.API.LoginRequest loginRequest)
		{
			var uriLogin = $"{enderecoBaseAPI}/Usuario/Buscar/{loginRequest.Login}/{loginRequest.Password}";
			using (WebClient webClient = new WebClient())
			{
				return JsonConvert.DeserializeObject<LTM.Entity.API.LoginResponse>(webClient.DownloadString(uriLogin));
			}
		}

		public void Cadastrar(Classes.Cadastrar cadastrar)
		{
			var uri = $"{enderecoBaseAPI}/Usuario/Cadastrar";

			var cadastrarAPI = new Entity.API.UsuarioCriacao()
			{
				Email = cadastrar.Email,
				Login = cadastrar.Login,
				Nome = cadastrar.Nome,
				Password = cadastrar.Senha
			};

			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			var myContent = JsonConvert.SerializeObject(cadastrarAPI);
			var content = new StringContent(myContent, Encoding.UTF8, "application/json");
			var result = client.PostAsync(uri, content).Result;
		}

		public List<Produto> ListarProdutos()
		{
			var uri = $"{enderecoBaseAPI}/Produto/BuscarTodos";
			var produtos = new List<Produto>();
			using (WebClient webClient = new WebClient())
			{
				var listaProd = JsonConvert.DeserializeObject<List<LTM.Entity.API.Produto>>(webClient.DownloadString(uri));
				listaProd.ForEach(x =>
				{
					produtos.Add(new Produto() { Descricao = x.Descricao, Especificacao = x.Especificacoes, Nome = x.Nome, QuantidadeEstoque = x.ItensEstoque });
				});

			}
			return produtos;
		}

		public void CadastrarProduto(Entity.API.ProdutoAdicionar cadastrar)
		{
			var uri = $"{enderecoBaseAPI}/Produto/Cadastrar";

			var client = new HttpClient();
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			var myContent = JsonConvert.SerializeObject(cadastrar);
			var content = new StringContent(myContent, Encoding.UTF8, "application/json");
			var result = client.PostAsync(uri, content).Result;
		}
	}
}
