using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Servico
{
    public interface IProcessoServico
    {
        Task<List<Processo>> Get();
        Task<Processo> Get(int id);
        Task<List<Processo>> BuscaPorTermo(string termo);
        Task<string> Add(ProcessoDto processoDto);
        Task<Processo> Update(ProcessoDto processoDto);
        Task<string> Delete(int id);
    }
}
