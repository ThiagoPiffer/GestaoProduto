using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Servico
{
    public class ProcessoServico : IProcessoServico
    {
        private readonly IRepositorio<Processo> _repositorio;
        private readonly IProcessoRepositorio _processoRepositorio;        

        public ProcessoServico(IRepositorio<Processo> repositorio,
                                        IProcessoRepositorio processoRepositorio)
        {
            _repositorio = repositorio;
            _processoRepositorio = processoRepositorio;            
        }

        public async Task<List<Processo>> Get()
        {
            var listaProcessos = _repositorio.ObterLista();

            return null;
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

        public async Task<string> Add(Processo processo)
        {
            try
            {
                _processoRepositorio.Armazenar(processo);
                return "Processo Salvo";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<Processo> Update(Processo processo, int id)
        {
            try
            {
                //_processoRepositorio.Editar(processo);
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
                var processo = _repositorio.ObterPorId(id);
                //_processoRepositorio.Deletar(processo);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}
