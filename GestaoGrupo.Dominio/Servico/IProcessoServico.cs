using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Dominio.Servico
{
    public interface IProcessoServico
    {
        Task<List<Processo>> Listar();
        Task<Processo> ObterPorId(int id);
        Task<List<Processo>> BuscaPorTermo(string termo);
        Task<Processo> Adicionar(ProcessoModel processoDto);
        Task<Processo> Editar(ProcessoModel processoDto);
        Task<Processo> EditarDto(ProcessoDto processoDto);

        Task<string> Delete(int id);
    }
}
