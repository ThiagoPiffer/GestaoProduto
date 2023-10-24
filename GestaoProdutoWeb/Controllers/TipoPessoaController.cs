﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.IServico._TipoPessoa;
using GestaoProduto.Dominio.Model._TipoPessoa;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPessoaController : ControllerBase
    {
        private readonly ITipoPessoaServico _tipoPessoaServico;

        public TipoPessoaController(ITipoPessoaServico tipoPessoaServico)
        {
            _tipoPessoaServico = tipoPessoaServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _tipoPessoaServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _tipoPessoaServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] TipoPessoaModel tipoPessoaModel)
        {
            TipoPessoa tipoPessoa = await _tipoPessoaServico.Adicionar(tipoPessoaModel);
            return Ok(tipoPessoa);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] TipoPessoaModel tipoPessoaModel)
        {
            TipoPessoa tipoPessoa = await _tipoPessoaServico.Editar(tipoPessoaModel);
            return Ok(tipoPessoa);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _tipoPessoaServico.Delete(id) });
        }
    }
}