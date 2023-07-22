using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;


namespace GestaoProduto.Servico
{
    public class ObjetoCustomizadoServico : IObjetoCustomizadoServico
    {
        private readonly IRepositorio<ObjetoCustomizado> _repositorio;
        private readonly IObjetoCustomizadoRepositorio _objetoCustomizadoRepositorio;
        private readonly IMapper _mapper;

        public ObjetoCustomizadoServico(IRepositorio<ObjetoCustomizado> repositorio,
                                        IObjetoCustomizadoRepositorio objetoCustomizadoRepositorio,
                                        IMapper mapper)
        {
            _repositorio = repositorio;
            _objetoCustomizadoRepositorio = objetoCustomizadoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ObjetoCustomizadoDTO>> Get()
        {
            var listaObjetosCustomizados = _repositorio.ObterLista();
            //var listaObjetosCustomizadosDto = _mapper.Map<List<ObjetoCustomizadoDTO>>(listaObjetosCustomizados);

            //return listaObjetosCustomizadosDto;
            return null;
        }

        public async Task<ObjetoCustomizadoDTO> Get(int id)
        {
            var produto = _repositorio.ObterPorId(id);
            var produtoDto = _mapper.Map<ObjetoCustomizadoDTO>(produto);

            return produtoDto;
        }

        public async Task<List<ObjetoCustomizadoDTO>> BuscaPorTermo(string termo)
        {
            List<ObjetoCustomizado> produto = _objetoCustomizadoRepositorio.BuscaPorTermo(termo);
            List<ObjetoCustomizadoDTO> listaObjetoCustomizadoDTO = new List<ObjetoCustomizadoDTO>();
            foreach (var item in produto)
            {
                var produtoDto = _mapper.Map<ObjetoCustomizadoDTO>(item);
                listaObjetoCustomizadoDTO.Add(produtoDto);
            }



            return listaObjetoCustomizadoDTO;
        }

        public async Task<string> Add(ObjetoCustomizadoDTO objetoCustomizadoDto)
        {
            try
            {
                _objetoCustomizadoRepositorio.Armazenar(objetoCustomizadoDto);
                return "ObjetoCustomizado Salvo";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<ObjetoCustomizadoDTO> Update(ObjetoCustomizadoDTO produtoDto, int id)
        {
            try
            {
                //_armazenadorObjetoCustomizado.Editar(produtoDto);
                return produtoDto;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
        public async Task<string> Delete(int id)
        {
            try
            {
                var produto = _repositorio.ObterPorId(id);
                var produtoDto = _mapper.Map<ObjetoCustomizadoDTO>(produto);
                //_armazenadorObjetoCustomizado.Deletar(produtoDto);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
