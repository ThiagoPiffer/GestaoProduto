using GestaoProduto.Dominio.Entity._GrupoProcesso;
using GestaoProduto.Dominio.Entity._GrupoProcessoDto;
using GestaoProduto.Dominio.Model._GrupoProcesso;


namespace GestaoProduto.Dominio.IServico._GrupoProcesso
{
    public interface IGrupoProcessoServico
    {
        Task CriaGrupoInicial();
        Task<List<GrupoProcessoModel>> Listar();
        Task<GrupoProcesso> Adicionar(GrupoProcessoDto grupoProcessoDto);
        Task<GrupoProcesso> Editar(GrupoProcessoDto grupoProcessoDto);
    }
}

