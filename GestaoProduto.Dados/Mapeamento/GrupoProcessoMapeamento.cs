using AutoMapper;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using GestaoProduto.Dominio.Entity._GrupoProcessoDto;

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
