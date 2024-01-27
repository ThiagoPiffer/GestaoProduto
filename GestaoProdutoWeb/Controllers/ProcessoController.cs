using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Compartilhado.Interfaces.Servico._Processo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]

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
        [Route("BuscarProcessoStatus")]
        public async Task<IActionResult> BuscarProcessoStatus(int processoId)
        {
            return Ok(await _processoServico.BuscarProcessoStatus(processoId));
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

        [HttpPut]
        [Route("ReabrirProcesso")]
        public async Task<IActionResult> ReabrirProcesso([FromBody] ProcessoModel model)
        {
            Processo obj = await _processoServico.ReabrirProcesso(model);
            return Ok(obj);
        }

        [HttpPut]
        [Route("Finalizar")]
        public async Task<IActionResult> Finalizar([FromBody] ProcessoModel model)
        {
            Processo obj = await _processoServico.Finalizar(model);
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
