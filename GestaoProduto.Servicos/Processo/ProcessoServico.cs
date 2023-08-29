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

        public async Task<ProcessoModel> ObterPorId(int id)
        {
            var processo = await _repositorio.ObterPorIdAsync(id);
            var processoModel = _mapper.Map<ProcessoModel>(processo);
            
            return processoModel;
        }

        public async Task<List<Processo>> BuscaPorTermo(string termo)
        {
            List<Processo> processos = await _processoRepositorio.BuscaPorTermo(termo);            
            return processos;
        }

        public async Task<Processo> Adicionar(ProcessoModel processoModel)
        {            
            var processo = _mapper.Map<Processo>(processoModel);                
            await _processoRepositorio.AdicionarAsync(processo);

            return processo;
        }

        public async Task<Processo> Editar(ProcessoModel processoModel)
        {            
            var processo = _mapper.Map<Processo>(processoModel);
            await _processoRepositorio.EditarAsync(processo);

            return processo;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }
    }
}
