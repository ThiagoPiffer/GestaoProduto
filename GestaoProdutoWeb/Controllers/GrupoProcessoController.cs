using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Servico;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]

    public class GrupoProcessoController : Controller
    {
        private readonly IRepositorio<GrupoProcesso> _repositorio;
        private readonly IGrupoProcessoServico _grupoProcessoServico;

        public GrupoProcessoController(IRepositorio<GrupoProcesso> repositorio,
                                    IGrupoProcessoServico grupoProcessoServico)
        {
            _repositorio = repositorio;
            _grupoProcessoServico = grupoProcessoServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _grupoProcessoServico.Listar());
        }

        [HttpGet]
        [Route("criaGrupoInicial")]
        public async Task<IActionResult> criaGrupoInicial()
        {
            await _grupoProcessoServico.CriaGrupoInicial();
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
