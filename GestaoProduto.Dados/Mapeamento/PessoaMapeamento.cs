using AutoMapper;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Compartilhado.Model._Pessoa;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;

namespace GestaoProduto.Dados.Mapeamento
{
    public class PessoaMapeamento : Profile
    {
        public PessoaMapeamento()
        {
            // Mapeando Pessoa para PessoaModel
            CreateMap<Pessoa, PessoaModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento.HasValue ? src.DataNascimento.Value.ToString("dd/MM/yyyy") : null))
                //.ForMember(dest => dest.Idade, opt => opt.MapFrom(src => src.Idade ?? 0))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CPFCNPJ, opt => opt.MapFrom(src => src.CPFCNPJ))
                .ForMember(dest => dest.Identidade, opt => opt.MapFrom(src => src.Identidade))
                .ForMember(dest => dest.DDDTelefone, opt => opt.MapFrom(src => src.DDDTelefone))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.DDDCelular, opt => opt.MapFrom(src => src.DDDCelular))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular))
                .ReverseMap();

            CreateMap<Pessoa, PessoaProcessoModel>();
        }
    }
}
