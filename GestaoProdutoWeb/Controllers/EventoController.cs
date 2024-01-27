using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Interfaces.Servico._Evento;
using GestaoProduto.Compartilhado.Model._Evento;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Dominio.Entity._Processo;
using Microsoft.AspNetCore.Authorization;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventoController : ControllerBase
    {
        private readonly IEventoServico _eventoServico;

        public EventoController(IEventoServico eventoServico)
        {
            _eventoServico = eventoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar([FromQuery] int processoId, bool exibeEncerrados = false)
        {
            return Ok(await _eventoServico.Listar(processoId, exibeEncerrados));
        }

        [HttpGet]
        [Route("BuscarEventoStatus")]
        public async Task<IActionResult> BuscarEventoStatus(int eventoId)
        {
            return Ok(await _eventoServico.BuscarEventoStatus(eventoId));
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _eventoServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] EventoModel eventoModel)
        {
            Evento evento = await _eventoServico.Adicionar(eventoModel);
            return Ok(evento);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] EventoModel eventoModel)
        {
            Evento evento = await _eventoServico.Editar(eventoModel);
            return Ok(evento);
        }

        [HttpPut]
        [Route("ReabrirEvento")]
        public async Task<IActionResult> ReabrirEvento([FromBody] EventoModel model)
        {
            Evento obj = await _eventoServico.ReabrirEvento(model);
            return Ok(obj);
        }

        [HttpPut]
        [Route("FinalizarEvento")]
        public async Task<IActionResult> FinalizarEvento([FromBody] EventoModel model)
        {
            Evento obj = await _eventoServico.FinalizarEvento(model);
            return Ok(obj);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _eventoServico.Delete(id) });
        }
    }
}
