using AutoMapper;
using GestaoProduto.Dominio.Entity;

namespace GestaoProduto.Dados.Mapeamento
{
    public class ProcessoMapeamento : Profile
    {
        public ProcessoMapeamento()
        {
            CreateMap<Processo, ProcessoDto>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                    .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                    .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                    .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
                    .ForMember(dest => dest.DataPrevista, opt => opt.MapFrom(src => src.DataPrevista))
                    .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.DataFinal))
                    .ForMember(dest => dest.ValorCausa, opt => opt.MapFrom(src => src.ValorCausa))
                    .ReverseMap();

            CreateMap<Processo, Processo>()
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro.ToString("dd/MM/yyyy")));
                //.ReverseMap();
        }
    }
}
