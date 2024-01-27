using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Compartilhado.Interfaces.Servico._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Model._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using Microsoft.AspNetCore.Authorization;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProcessoStatusPersonalizadoController : ControllerBase
    {
        private readonly IProcessoStatusPersonalizadoServico _processoStatusPersonalizadoServico;

        public ProcessoStatusPersonalizadoController(IProcessoStatusPersonalizadoServico processoStatusPersonalizadoServico)
        {
            _processoStatusPersonalizadoServico = processoStatusPersonalizadoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _processoStatusPersonalizadoServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _processoStatusPersonalizadoServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] ProcessoStatusPersonalizadoModel processoStatusPersonalizadoModel)
        {
            ProcessoStatusPersonalizado processoStatusPersonalizado = await _processoStatusPersonalizadoServico.Adicionar(processoStatusPersonalizadoModel);
            return Ok(processoStatusPersonalizado);
        }

        [HttpGet]
        [Route("AdicionarStatusPadraoProcesso")]
        public async Task<IActionResult> AdicionarStatusPadraoProcesso()
        {
            await _processoStatusPersonalizadoServico.AdicionarStatusPadraoProcesso();
            return Ok(new { message = "Status criado" });
        }        

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProcessoStatusPersonalizadoModel processoStatusPersonalizadoModel)
        {
            ProcessoStatusPersonalizado processoStatusPersonalizado = await _processoStatusPersonalizadoServico.Editar(processoStatusPersonalizadoModel);
            return Ok(processoStatusPersonalizado);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok(new { mensagem = await _processoStatusPersonalizadoServico.Delete(id) });
        }
    }
}
