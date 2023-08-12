using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Servico;

namespace GestaoProduto.Servico
{
    public class ProdutoServico : IProdutoServico
    {
        private readonly IRepositorio<Produto> _repositorio;
        private readonly ArmazenadorProduto _armazenadorProduto;
        private readonly IMapper _mapper;

        public ProdutoServico(IRepositorio<Produto> repositorio,
                        ArmazenadorProduto armazenadorProduto,
                        IMapper mapper)
        {
            _repositorio = repositorio;
            _armazenadorProduto = armazenadorProduto;
            _mapper = mapper;
        }

        public async Task<List<ProdutoDto>> Get()
        {
            var listaProdutos = _repositorio.ObterListaAsync();
            var listaProdutosDto = _mapper.Map<List<ProdutoDto>>(listaProdutos);

            return listaProdutosDto;
        }

        public async Task<ProdutoDto> Get(int id)
        {
            var produto = _repositorio.ObterPorIdAsync(id);
            var produtoDto = _mapper.Map<ProdutoDto>(produto);

            return produtoDto;
        }

        public async Task<List<ProdutoDto>> BuscaPorTermo(string termo)
        {
            List<Produto> produto = _armazenadorProduto.BuscaPorTermo(termo);
            List<ProdutoDto> listaProdutoDto = new List<ProdutoDto>();
            foreach (var item in produto)
            {
                var produtoDto = _mapper.Map<ProdutoDto>(item);
                listaProdutoDto.Add(produtoDto);
            }
            
            

            return listaProdutoDto;
        }

        public async Task<string> Add(ProdutoDto produtoDto)
        {
            try
            {
                _armazenadorProduto.Armazenar(produtoDto);
                return "Produto Salvo";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<ProdutoDto> Update(ProdutoDto produtoDto, int id)
        {
            try
            {
                _armazenadorProduto.Editar(produtoDto);
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
                var produto = _repositorio.ObterPorIdAsync(id);
                var produtoDto = _mapper.Map<ProdutoDto>(produto);
                _armazenadorProduto.Deletar(produtoDto);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            { 
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
