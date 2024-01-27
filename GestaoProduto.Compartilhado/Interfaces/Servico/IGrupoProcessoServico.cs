using GestaoProduto.Compartilhado.Model._GrupoProcesso;
using GestaoProduto.Compartilhado.Model._GrupoProcessoDto;
using GestaoProduto.Dominio.Entity._GrupoProcesso;


namespace GestaoProduto.Compartilhado.Interfaces.Servico._GrupoProcesso
{
    public interface IGrupoProcessoServico
    {
        void CriaGrupoInicial();
        Task<List<GrupoProcessoModel>> Listar(bool exibeFinalizados = false);
        Task<GrupoProcesso> Adicionar(GrupoProcessoDto grupoProcessoDto);
        Task<GrupoProcesso> Editar(GrupoProcessoDto grupoProcessoDto);
        Task<string> Delete(int id);
    }
}

