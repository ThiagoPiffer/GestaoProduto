using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Servico
{
    public class PessoaServico : IPessoaServico
    {
        private readonly IRepositorio<Pessoa> _repositorio;
        private readonly IRepositorio<PessoasProcesso> _repositorioPessoasProcesso;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IProcessoRepositorio _processoRepositorio;
        private readonly IMapper _mapper;

        public PessoaServico(IRepositorio<Pessoa> repositorio,
                             IRepositorio<PessoasProcesso> repositorioPessoasProcesso,
                             IPessoaRepositorio pessoaRepositorio,
                             IProcessoRepositorio processoRepositorio,
                             IMapper mapper)
        {
            _repositorio = repositorio;
            _repositorioPessoasProcesso = repositorioPessoasProcesso;
            _pessoaRepositorio = pessoaRepositorio;
            _processoRepositorio = processoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<Pessoa>> Listar()
        {
            var listaPessoas = await _repositorio.ObterListaAsync();
            var mappedPessoas = _mapper.Map<List<Pessoa>>(listaPessoas);
            return mappedPessoas;
        }

        public async Task<List<PessoasProcessoModel>> ListarPessoasProcesso(int idProcesso)
        {
            var listaPessoas = await _pessoaRepositorio.ListarPessoasProcesso(idProcesso);
            return listaPessoas;
        }

        public async Task<PessoaModel> ObterPorId(int id)
        {
            var pessoa = await _repositorio.ObterPorIdAsync(id);
            var pessoaModel = _mapper.Map<PessoaModel>(pessoa);

            return pessoaModel;
        }

        public async Task<Pessoa> Adicionar(PessoaModel pessoaModel, int idProcesso)
        {
            var processo = await _processoRepositorio.ObterPorIdAsync(idProcesso);

            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            pessoa = await _pessoaRepositorio.AdicionarAsyncSaveChanges(pessoa);

            var pessoasProcesso = new PessoasProcesso();
            pessoasProcesso.ProcessoId = idProcesso;
            pessoasProcesso.PessoaId = pessoa.Id;
            pessoasProcesso.Ativo = true;

            await _repositorioPessoasProcesso.AdicionarAsyncSaveChanges(pessoasProcesso);

            return pessoa;
        }

        public async Task<Pessoa> Editar(PessoaModel pessoaDto)
        {
            try
            {
                var pessoa = _mapper.Map<Pessoa>(pessoaDto);
                await _pessoaRepositorio.EditarAsync(pessoa);

                return pessoa;
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
                var pessoa = await _repositorio.ObterPorIdAsync(id);
                await _repositorio.ExcluirAsync(pessoa);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
