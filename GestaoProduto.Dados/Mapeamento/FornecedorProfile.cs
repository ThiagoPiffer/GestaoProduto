using AutoMapper;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dados.Mapeamento
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<Fornecedor, FornecedorDto>()
                .ReverseMap();
        }
    }
}
