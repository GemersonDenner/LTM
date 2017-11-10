using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LTM.View.Classes;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;

namespace LTM.View.Pages
{
	public class InicioModel : PageModel
	{
		public bool UsuarioLogado { get; set; }

		[BindProperty]
		public Logar EfetuarLogin { get; set; }

		[BindProperty]
		public Cadastrar EfetuarCadastro { get; set; }

		public List<Produto> produtos { get; set; }


		public void OnGet()
		{
			UsuarioLogado = false;
			produtos = new List<Produto>();
		}


		public async Task<IActionResult> OnPostLoginAsync()
		{

			var uriCategorias = "http://localhost:8090/api/Produto/BuscarTodos";
			using (WebClient webClient = new WebClient())
			{
				var listaProd = JsonConvert.DeserializeObject<List<LTM.Entity.API.Produto>>(webClient.DownloadString(uriCategorias));
				this.produtos = new List<Produto>();
				listaProd.ForEach(x => {
					produtos.Add(new Produto() { Descricao = x.Descricao, Especificacao = x.Especificacoes, Nome = x.Nome, QuantidadeEstoque = x.ItensEstoque });
				});

			}

			return Page();
		}

		public async Task<IActionResult> OnPostCadastrarAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			return RedirectToPage("/Inicio");
		}
	}
}