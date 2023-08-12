using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;


namespace GestaoProduto.Dominio.Servico
{
    public interface IGrupoProcessoServico
    {
        Task CriaGrupoInicial();
        Task<List<GrupoProcessoModel>> Listar();
        Task<GrupoProcesso> Adicionar(GrupoProcessoDto grupoProcessoDto);
        Task<GrupoProcesso> Editar(GrupoProcessoDto grupoProcessoDto);
    }
}
