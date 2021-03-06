﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LTM.Entity.DAL;
using AutoMapper;
using LTM.DAL.Repository;
using Microsoft.AspNetCore.Authorization;

namespace LTM.Api.Controllers
{
	[Produces("application/json")]
	[Route("api/Produto")]
	public class ProdutoController : Controller
	{
		private IMapper _mapper;

		public IProdutoRepository _ProdutoRepository { get; }

		public ProdutoController(IProdutoRepository produtoRepository, IMapper mapper)
		{
			_ProdutoRepository = produtoRepository;
			_mapper = mapper;
		}

		[Authorize]
		[HttpGet("BuscarTodos/")]
		public IEnumerable<Entity.API.Produto> BuscarTodos()
		{
			var produtos = _ProdutoRepository.BuscarTodos();
			return _mapper.Map<IEnumerable<Entity.API.Produto>>(produtos);
		}

		[Authorize(Roles = "USUARIO")]
		[HttpGet("BuscarTodos/{idProduto}")]
		public Entity.API.Produto Buscar(Guid idProduto)
		{
			var produto = _ProdutoRepository.Buscar(idProduto);
			return _mapper.Map<Entity.API.Produto>(produto);
		}

		[Authorize(Roles = "USUARIO")]
		[HttpDelete("Deletar/{idProduto}")]
		public void Deletar(Guid idProduto)
		{
			_ProdutoRepository.Deletar(idProduto);
		}

		[Authorize(Roles = "USUARIO")]
		[HttpPost("Atualizar/")]
		public void Atualizar([FromBody]Entity.API.Produto produto)
		{
			var prodDal = _mapper.Map<Entity.DAL.Produto>(produto);
			_ProdutoRepository.Atualizar(prodDal);
		}

		[Authorize(Roles = "USUARIO")]
		[HttpPost("Cadastrar/")]
		public void Cadastrar([FromBody]Entity.API.ProdutoAdicionar produto)
		{
			var prodDal = _mapper.Map<Entity.DAL.Produto>(produto);
			_ProdutoRepository.Cadastrar(prodDal);
		}
	}
}