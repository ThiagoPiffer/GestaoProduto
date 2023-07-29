using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Servico;
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
        public async Task<IActionResult> Get()
        {
            return Ok(await _processoServico.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProcessoDto processoDto)
        {
            return Ok(await _processoServico.Add(processoDto));
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProcessoDto processoDto)
        {
            return Ok(await _processoServico.Update(processoDto));
        }

        [HttpDelete]
        public async Task<IActionResult> Deletar([FromBody] int id)
        {
            return Ok(await _processoServico.Delete(id));
        }
    }
}
