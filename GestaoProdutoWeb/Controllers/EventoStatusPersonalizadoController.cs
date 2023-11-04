﻿using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Compartilhado.Interfaces.Servico._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Model._EventoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoStatusPersonalizadoController : ControllerBase
    {
        private readonly IEventoStatusPersonalizadoServico _eventoStatusPersonalizadoServico;

        public EventoStatusPersonalizadoController(IEventoStatusPersonalizadoServico eventoStatusPersonalizadoServico)
        {
            _eventoStatusPersonalizadoServico = eventoStatusPersonalizadoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _eventoStatusPersonalizadoServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _eventoStatusPersonalizadoServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] EventoStatusPersonalizadoModel eventoStatusPersonalizadoModel)
        {
            EventoStatusPersonalizado eventoStatusPersonalizado = await _eventoStatusPersonalizadoServico.Adicionar(eventoStatusPersonalizadoModel);
            return Ok(eventoStatusPersonalizado);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] EventoStatusPersonalizadoModel eventoStatusPersonalizadoModel)
        {
            EventoStatusPersonalizado eventoStatusPersonalizado = await _eventoStatusPersonalizadoServico.Editar(eventoStatusPersonalizadoModel);
            return Ok(eventoStatusPersonalizado);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _eventoStatusPersonalizadoServico.Delete(id) });
        }
    }
}
