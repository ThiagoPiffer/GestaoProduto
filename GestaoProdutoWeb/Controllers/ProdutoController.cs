using Microsoft.AspNetCore.Mvc;
using GestaoProduto.Dominio.Produtos;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Servico.ProdutoServico;
using AutoMapper;

namespace GestaoProduto.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IRepositorio<Produto> _repositorio;
        private readonly ArmazenadorProduto _armazenadorProduto;
        private readonly IMapper _mapper;
        private readonly IProdutoServico _produtoServico;

        public ProdutoController(IRepositorio<Produto> repositorio,
                                    ArmazenadorProduto armazenadorProduto,
                                    IProdutoServico produtoServico,
                                    IMapper mapper)
        {
            _repositorio = repositorio;
            _armazenadorProduto = armazenadorProduto;
            _mapper = mapper;
            _produtoServico = produtoServico;
        }

        // {endereco_site}/api/fornecedor
        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            return Ok(await _produtoServico.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _produtoServico.Get(id));
        }

        [HttpGet("BuscaPorTermo/{termo}")]
        public async Task<IActionResult> BuscaPorTermo(string termo)
        {
            return Ok(await _produtoServico.BuscaPorTermo(termo));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProdutoDto produtoDto)
        {
            return Ok(await _produtoServico.Add(produtoDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ProdutoDto produtoDto, int id)
        {
            return Ok(await _produtoServico.Update(produtoDto, id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _produtoServico.Delete(id));
        }
    }
}
