﻿using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GestaoProduto.Identidade;
using System.IdentityModel.Tokens.Jwt;
using GestaoProduto.Compartilhado.Interfaces.Servico._GrupoProcesso;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Model._GrupoProcessoDto;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]


    public class GrupoProcessoController : Controller
    {
        private readonly IRepositorio<GrupoProcesso> _repositorio;
        private readonly IGrupoProcessoServico _grupoProcessoServico;
        private readonly IUser _user;


        public GrupoProcessoController(IRepositorio<GrupoProcesso> repositorio,
                                       IGrupoProcessoServico grupoProcessoServico,
                                       IUser user)
        {
            _repositorio = repositorio;
            _grupoProcessoServico = grupoProcessoServico;
            _user=user;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _grupoProcessoServico.Listar());
        }

        [HttpGet]
        [Route("criaGrupoInicial")]
        public IActionResult criaGrupoInicial()
        {
            _grupoProcessoServico.CriaGrupoInicial();
            return Ok("OK");
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] GrupoProcessoDto grupoProcessoDto)
        {
            try
            {
                GrupoProcesso processo = await _grupoProcessoServico.Adicionar(grupoProcessoDto);
                return Ok(processo);
            }
            catch (Exception ex)
            {
                // Retorna um erro 500 e a mensagem da exceção.
                return StatusCode(500, $"Um erro ocorreu: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] GrupoProcessoDto grupoProcessoDto)
        {
            try
            {
                GrupoProcesso processo = await _grupoProcessoServico.Editar(grupoProcessoDto);
                return Ok(processo);
            }
            catch (Exception ex)
            {
                // Retorna um erro 500 e a mensagem da exceção.
                return StatusCode(500, $"Um erro ocorreu: {ex.Message}");
            }
        }
    }
}
