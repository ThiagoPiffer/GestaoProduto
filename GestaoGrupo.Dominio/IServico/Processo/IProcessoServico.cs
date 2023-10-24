using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Model._Processo;

namespace GestaoProduto.Dominio.IServico._Processo
{
    public interface IProcessoServico
    {
        Task<List<Processo>> Listar();
        Task<ProcessoModel> ObterPorId(int id);
        Task<List<Processo>> BuscaPorTermo(string termo);
        Task<Processo> Adicionar(ProcessoModel processoModel);
        Task<Processo> Editar(ProcessoModel processoModel);
        Task<string> Delete(int id);
    }
}
