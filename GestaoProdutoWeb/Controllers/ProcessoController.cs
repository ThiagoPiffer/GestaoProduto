﻿using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Compartilhado.Interfaces.Servico._Processo;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    public class ProcessoController : Controller
    {
        private readonly IRepositorio<Processo> _repositorio;
        private readonly IProcessoServico _processoServico;

        public ProcessoController(IRepositorio<Processo> repositorio,
                                    IProcessoServico processoServico)
        {
            _repositorio = repositorio;
            _processoServico = processoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _processoServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _processoServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] ProcessoModel model)
        {
            Processo obj = await _processoServico.Adicionar(model);
            return Ok(obj);  
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProcessoModel model)
        {
            Processo obj = await _processoServico.Editar(model);
            return Ok(obj);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok( new { mensagem = await _processoServico.Delete(id) });            
        }
    }
}
