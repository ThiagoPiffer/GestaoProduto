using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Dominio.Servico
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
