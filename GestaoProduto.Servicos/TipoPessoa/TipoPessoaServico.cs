using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.IRepositorio._TipoPessoa;
using GestaoProduto.Dominio.IServico._TipoPessoa;
using GestaoProduto.Dominio.Model._TipoPessoa;

namespace GestaoProduto.Servico._TipoPessoa
{
    public class TipoPessoaServico : ITipoPessoaServico
    {
        private readonly IRepositorio<TipoPessoa> _repositorio;
        private readonly ITipoPessoaRepositorio _tipoPessoaRepositorio;
        private readonly IMapper _mapper;

        public TipoPessoaServico(IRepositorio<TipoPessoa> repositorio,
                                        ITipoPessoaRepositorio tipoPessoaRepositorio,
                                        IMapper mapper)
        {
            _repositorio = repositorio;
            _tipoPessoaRepositorio = tipoPessoaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<TipoPessoa>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<TipoPessoa>>(listaObj);
            return listaObj;
        }

        public async Task<TipoPessoaModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<TipoPessoaModel>(Obj);

            return objModel;
        }

        public async Task<List<TipoPessoa>> BuscaPorTermo(string termo)
        {
            List<TipoPessoa> lista = await _tipoPessoaRepositorio.BuscaPorTermo(termo);
            return lista;
        }

        public async Task<TipoPessoa> Adicionar(TipoPessoaModel model)
        {
            var obj = _mapper.Map<TipoPessoa>(model);
            await _tipoPessoaRepositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<TipoPessoa> Editar(TipoPessoaModel model)
        {
            var obj = _mapper.Map<TipoPessoa>(model);
            await _tipoPessoaRepositorio.EditarAsync(obj);

            return obj;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }
    }
}