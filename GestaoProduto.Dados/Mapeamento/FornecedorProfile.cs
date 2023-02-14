using AutoMapper;
using GestaoProduto.Dominio.Fornecedores;

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
