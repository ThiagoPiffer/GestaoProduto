using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Servico;

namespace GestaoProduto.Servico
{
    public class FornecedorServico : IFornecedorServico
    {
        private readonly IRepositorio<Fornecedor> _repositorio;
        private readonly ArmazenadorFornecedor _armazenadorFornecedor;
        private readonly IMapper _mapper;

        public FornecedorServico(IRepositorio<Fornecedor> repositorio,
                        ArmazenadorFornecedor armazenadorFornecedor,
                        IMapper mapper)
        {
            _repositorio = repositorio;
            _armazenadorFornecedor = armazenadorFornecedor;
            _mapper = mapper;
        }

        public async Task<List<FornecedorDto>> Get()
        {
            var listaFornecedores = _repositorio.ObterListaAsync();
            var listaFornecedoresDto = _mapper.Map<List<FornecedorDto>>(listaFornecedores);

            return listaFornecedoresDto;
        }

        public async Task<FornecedorDto> Get(int id)
        {
            try
            {
                var fornecedor = _repositorio.ObterPorIdAsync(id);
                var fornecedorDto = _mapper.Map<FornecedorDto>(fornecedor);

                return fornecedorDto;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }


        public async Task<FornecedorDto> Add(FornecedorDto fornecedorDto)
        {
            try
            {
                _armazenadorFornecedor.Armazenar(fornecedorDto);
                return fornecedorDto;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<FornecedorDto> Update(FornecedorDto fornecedorDto, int id)
        {
            try
            {
                _armazenadorFornecedor.Editar(fornecedorDto);
                return fornecedorDto;
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
                var fornecedor = _repositorio.ObterPorIdAsync(id);
                var fornecedorDto = _mapper.Map<FornecedorDto>(fornecedor);
                _armazenadorFornecedor.Deletar(fornecedorDto);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
