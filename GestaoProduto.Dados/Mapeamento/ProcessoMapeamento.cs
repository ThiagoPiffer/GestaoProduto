using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Model;

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
            .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro.HasValue ? src.DataCadastro.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio.HasValue ? src.DataInicio.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataPrevista, opt => opt.MapFrom(src => src.DataPrevista.HasValue ? src.DataPrevista.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.DataFinal.HasValue ? src.DataFinal.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.ValorCausa, opt => opt.MapFrom(src => src.ValorCausa))
            .ReverseMap();

            CreateMap<Processo, ProcessoModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro.HasValue ? src.DataCadastro.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio.HasValue ? src.DataInicio.Value.ToString("dd/MM/yyyy") : null))

            .ForMember(dest => dest.Prazo, opt => opt.MapFrom(src => src.DataInicio.HasValue && src.DataCadastro.HasValue ? (src.DataInicio.Value - src.DataCadastro.Value).TotalDays : (double?)null))

            .ForMember(dest => dest.DataPrevista, opt => opt.MapFrom(src => src.DataPrevista.HasValue ? src.DataPrevista.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.DataFinal.HasValue ? src.DataFinal.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.ValorCausa, opt => opt.MapFrom(src => src.ValorCausa))
            .ReverseMap();
        }
    }
}
