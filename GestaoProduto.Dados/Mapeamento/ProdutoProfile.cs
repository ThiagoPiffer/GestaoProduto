using AutoMapper;
using GestaoProduto.Dominio.Produtos;

namespace GestaoProduto.Dados.Mapeamento
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                //.ForMember(p => p.Id, map => map.MapFrom(s => s.Id))
                //.ForMember(p => p.Ativo, map => map.MapFrom(s => s.Ativo))
                .ReverseMap();
        }
    }
}
