using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Servico
{
    public class ProcessoServico : IProcessoServico
    {
        private readonly IRepositorio<Processo> _repositorio;
        private readonly IProcessoRepositorio _processoRepositorio;
        private readonly IMapper _mapper;

        public ProcessoServico(IRepositorio<Processo> repositorio,
                                        IProcessoRepositorio processoRepositorio,
                                        IMapper mapper)
        {
            _repositorio = repositorio;
            _processoRepositorio = processoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<Processo>> Listar()
        {
            var listaProcessos = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<Processo>>(listaProcessos);
            return listaProcessos;
        }

        public async Task<Processo> ObterPorId(int id)
        {
            var processo = await _repositorio.ObterPorIdAsync(id);
            
            return processo;
        }

        public async Task<List<Processo>> BuscaPorTermo(string termo)
        {
            List<Processo> processos = await _processoRepositorio.BuscaPorTermo(termo);            
            return processos;
        }

        public async Task<Processo> Adicionar(ProcessoModel processoDto)
        {
            try
            {
                var processo = _mapper.Map<Processo>(processoDto);                
                await _processoRepositorio.AdicionarAsync(processo);

                return processo;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<Processo> Editar(ProcessoModel processoDto)
        {
            try
            {
                var processo = _mapper.Map<Processo>(processoDto);
                await _processoRepositorio.EditarAsync(processo);

                return processo;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<Processo> EditarDto(ProcessoDto processoDto)
        {
            try
            {
                var processo = _mapper.Map<Processo>(processoDto);
                await _processoRepositorio.EditarAsync(processo);

                return processo;
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
                var obj = await _repositorio.ObterPorIdAsync(id);
                await _repositorio.ExcluirAsync(obj);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
