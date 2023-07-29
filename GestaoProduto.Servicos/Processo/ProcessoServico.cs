using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using System.Diagnostics;

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

        public async Task<List<Processo>> Get()
        {
            var listaProcessos = _repositorio.ObterLista();
            var x = _mapper.Map<List<Processo>>(listaProcessos);
            return listaProcessos;
        }

        public async Task<Processo> Get(int id)
        {
            var processo = _repositorio.ObterPorId(id);
            

            return processo;
        }

        public async Task<List<Processo>> BuscaPorTermo(string termo)
        {
            List<Processo> processos = _processoRepositorio.BuscaPorTermo(termo);            
            return processos;
        }

        public async Task<string> Add(ProcessoDto processoDto)
        {
            try
            {
                var processo = _mapper.Map<Processo>(processoDto);
                _processoRepositorio.Armazenar(processo);

                return "OK";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<Processo> Update(ProcessoDto processoDto)
        {
            try
            {
                var processo = _mapper.Map<Processo>(processoDto);
                _processoRepositorio.Update(processo);

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
                _processoRepositorio.Delete(id);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
