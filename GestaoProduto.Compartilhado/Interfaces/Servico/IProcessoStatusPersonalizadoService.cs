using GestaoProduto.Compartilhado.Model._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;

namespace GestaoProduto.Compartilhado.Interfaces.Servico._ProcessoStatusPersonalizado
{
    public interface IProcessoStatusPersonalizadoServico
    {
        Task<List<ProcessoStatusPersonalizado>> Listar();
        Task<ProcessoStatusPersonalizadoModel> ObterPorId(int id);
        Task<ProcessoStatusPersonalizado> Adicionar(ProcessoStatusPersonalizadoModel processoStatusPersonalizadoModel);        
        Task<ProcessoStatusPersonalizado> Editar(ProcessoStatusPersonalizadoModel processoStatusPersonalizadoModel);
        Task<string> Delete(int id);
    }
}