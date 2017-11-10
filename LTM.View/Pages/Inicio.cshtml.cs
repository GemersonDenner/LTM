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
		private Classes.ConexaoAPI _conexaoAPI;

		public InicioModel(Classes.ConexaoAPI conexaoAPI)
		{
			_conexaoAPI = conexaoAPI;
		}
		[BindProperty]
		public bool UsuarioLogado { get; set; }

		[BindProperty]
		public Entity.API.LoginResponse DadosLogin { get; set; }

		[BindProperty]
		public Logar EfetuarLogin { get; set; }

		[BindProperty]
		public Cadastrar EfetuarCadastro { get; set; }

		public List<Produto> produtos { get; set; }

		[BindProperty]
		public Entity.API.ProdutoAdicionar CadastrarProduto { get; set; }


		public void OnGet()
		{
		}

		public async Task<IActionResult> OnPostLoginAsync()
		{
			this.DadosLogin = _conexaoAPI.Login(new Entity.API.LoginRequest() { Login = EfetuarLogin.Login, Password = EfetuarLogin.Senha });
			if (DadosLogin != null)
			{
				UsuarioLogado = true;
				this.produtos = _conexaoAPI.ListarProdutos();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostCadastrarAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			_conexaoAPI.Cadastrar(this.EfetuarCadastro);

			return Page();
		}

		public async Task<IActionResult> OnPostCadastrarProdutoAsync()
		{
			_conexaoAPI.CadastrarProduto(this.CadastrarProduto);
			this.CadastrarProduto = new Entity.API.ProdutoAdicionar();

			this.produtos = _conexaoAPI.ListarProdutos();
			return Page();
		}
	}
}