using AutoMapper;
using GestaoProduto.Compartilhado.Model._GrupoProcessoDto;
using GestaoProduto.Dominio.Entity._GrupoProcesso;

namespace GestaoProduto.Dados.Mapeamento
{
    public class GrupoProcessoMapeamento : Profile
    {
        public GrupoProcessoMapeamento()
        {
            CreateMap<GrupoProcesso, GrupoProcessoDto>()
            .ReverseMap();

        }
    }
}
