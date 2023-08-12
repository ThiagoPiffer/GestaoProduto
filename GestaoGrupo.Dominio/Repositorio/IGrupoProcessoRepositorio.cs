using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dominio.Repositorio
{
    public interface IGrupoProcessoRepositorio
    {
        Task Armazenar(GrupoProcesso grupoProcesso);
        Task<List<GrupoProcesso>> ObterListaAsync();
    }
}
