using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Servico;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProduto.API.Controllers
{
    [Route("api/[controller]")]
    public class ObjetosCustomizadosController : ControllerBase
    {
        private readonly IRepositorio<ObjetoCustomizado> _repositorio;           
        private readonly IMapper _mapper;
        private readonly IObjetoCustomizadoServico _objetoCustomizadoServico;

        public ObjetosCustomizadosController(IRepositorio<ObjetoCustomizado> repositorio,
                                    IObjetoCustomizadoServico objetoCustomizadoServico,
                                    IMapper mapper)
        {
            _repositorio = repositorio;            
            _mapper = mapper;
            _objetoCustomizadoServico = objetoCustomizadoServico;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _objetoCustomizadoServico.Get());
            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ObjetoCustomizadoDTO objetoCustomizadoDTO)
        {
            //return Ok(await _objetoCustomizadoServico.Add(objetoCustomizadoDTO));
            return null;
        }
    }
}
