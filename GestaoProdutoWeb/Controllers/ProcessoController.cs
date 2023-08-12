using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;
using GestaoProduto.Dominio.Servico;
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
        public async Task<IActionResult> Adicionar([FromBody] ProcessoModel processoDto)
        {
            try
            {
                Processo processo = await _processoServico.Adicionar(processoDto);
                return Ok(processo);
            }catch (Exception ex)
            {
                // Retorna um erro 500 e a mensagem da exceção.
                return StatusCode(500, $"Um erro ocorreu: {ex.Message}");
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProcessoModel processoDto)
        {
            Processo processo = await _processoServico.Editar(processoDto);
            return Ok(processo);
        }


        [HttpPut]
        [Route("EditarDto")]
        public async Task<IActionResult> EditarDto([FromBody] ProcessoDto processoDto)
        {
            Processo processo = await _processoServico.EditarDto(processoDto);
            return Ok(processo);
        }

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok( new { mensagem = await _processoServico.Delete(id) });            
        }
    }
}
