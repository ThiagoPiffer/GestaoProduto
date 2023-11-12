using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Compartilhado.Interfaces.Servico._Evento;
using GestaoProduto.Compartilhado.Model._Evento;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoServico _eventoServico;

        public EventoController(IEventoServico eventoServico)
        {
            _eventoServico = eventoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar([FromQuery] int processoId)
        {
            return Ok(await _eventoServico.Listar(processoId));
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

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _eventoServico.Delete(id) });
        }
    }
}
