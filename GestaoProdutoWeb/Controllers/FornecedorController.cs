using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Fornecedores;
using GestaoProduto.Servico.FornecedorServico;


namespace GestaoProduto.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {        
        private readonly IFornecedorServico _fornecedorServico;

        public FornecedorController(IFornecedorServico fornecedorServico)
        {         
            _fornecedorServico = fornecedorServico;
        }

        // {endereco_site}/api/fornecedor
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _fornecedorServico.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _fornecedorServico.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FornecedorDto fornecedorDto)
        {
            return Ok(await _fornecedorServico.Add(fornecedorDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] FornecedorDto fornecedorDto, int id)
        {
            return Ok(await _fornecedorServico.Update(fornecedorDto, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _fornecedorServico.Delete(id));
        }
    }
}
