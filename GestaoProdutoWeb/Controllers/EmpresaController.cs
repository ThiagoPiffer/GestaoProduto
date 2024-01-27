using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Compartilhado.Interfaces.Servico._Empresa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class EmpresaController : Controller
    {
        private readonly IRepositorio<Empresa> _repositorio;
        private readonly IEmpresaServico _empresaServico;

        public EmpresaController(IRepositorio<Empresa> repositorio,
                                    IEmpresaServico empresaServico)
        {
            _repositorio = repositorio;
            _empresaServico = empresaServico;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            return Ok(await _empresaServico.Listar());
        }

        [HttpGet]
        [Route("ObterPorId")]
        public async Task<IActionResult> ObterPorId([FromQuery] int id)
        {
            return Ok(await _empresaServico.ObterPorId(id));
        }

        [HttpPost]
        [Route("Adicionar")]
        public async Task<IActionResult> Adicionar([FromBody] EmpresaModel empresaModel)
        {
            Empresa empresa = await _empresaServico.Adicionar(empresaModel);
            return Ok(empresa);  
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] EmpresaModel empresaModel)
        {
            Empresa empresa = await _empresaServico.Editar(empresaModel);
            return Ok(empresa);
        }


        //[HttpPut]
        //[Route("EditarDto")]
        //public async Task<IActionResult> EditarDto([FromBody] EmpresaDto empresaDto)
        //{
        //    Empresa empresa = await _empresaServico.EditarDto(empresaDto);
        //    return Ok(empresa);
        //}

        [HttpDelete]
        [Route("Deletar")]
        public async Task<IActionResult> Deletar([FromQuery] int id)
        {
            return Ok( new { mensagem = await _empresaServico.Delete(id) });            
        }
    }
}
