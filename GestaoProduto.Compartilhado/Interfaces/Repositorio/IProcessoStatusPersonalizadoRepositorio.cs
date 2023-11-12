using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._TipoPessoa;

namespace GestaoProduto.Compartilhado.Interfaces.Repositorio._ProcessoStatusPersonalizado
{
    public interface IProcessoStatusPersonalizadoRepositorio : IRepositorio<ProcessoStatusPersonalizado>
    {
        Task<ProcessoStatusPersonalizado> BuscarProcessoStatus(int processoId, int empresaId);
    }
}