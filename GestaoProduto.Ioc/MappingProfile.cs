using AutoMapper;
using GestaoProduto.Compartilhado.Model._ArquivoProcesso;
using GestaoProduto.Compartilhado.Model._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Compartilhado.Model._Evento;
using GestaoProduto.Compartilhado.Model._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Model._GrupoProcessoDto;
using GestaoProduto.Compartilhado.Model._Pessoa;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;
using GestaoProduto.Compartilhado.Model._Processo;
using GestaoProduto.Compartilhado.Model._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Model._TipoPessoa;
using GestaoProduto.Compartilhado.Model._Usuario;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.Entity._Evento;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._TipoPessoa;
using GestaoProduto.Dominio.Entity._TipoPessoaTemplate;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Model._TipoPessoaTemplate;

namespace GestaoProduto.Ioc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ArquivoProcesso, ArquivoProcessoModel>().ReverseMap();
            CreateMap<UsuarioModel, Usuario>().ReverseMap();
            CreateMap<TipoPessoaTemplateModel, TipoPessoaTemplate>().ReverseMap();
            CreateMap<TipoPessoaModel, TipoPessoa>().ReverseMap();

            CreateMap<Processo, ProcessoModel>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
            .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
            //.ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro.HasValue ? src.DataCadastro.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio.HasValue ? src.DataInicio.Value.ToString("dd/MM/yyyy") : null))

            .ForMember(dest => dest.Prazo, opt => opt.MapFrom(src => src.DataPrevista.HasValue ? (src.DataPrevista.Value - DateTime.Now).TotalDays : (double?)null))

            .ForMember(dest => dest.DataPrevista, opt => opt.MapFrom(src => src.DataPrevista.HasValue ? src.DataPrevista.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.DataFinal, opt => opt.MapFrom(src => src.DataFinal.HasValue ? src.DataFinal.Value.ToString("dd/MM/yyyy") : null))
            .ForMember(dest => dest.ValorCausa, opt => opt.MapFrom(src => src.ValorCausa))
            .ReverseMap();

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

            CreateMap<Pessoa, PessoaProcessoModel>().ReverseMap();
            CreateMap<GrupoProcesso, GrupoProcessoDto>().ReverseMap();
            CreateMap<EmpresaModel, Empresa>().ReverseMap();
            CreateMap<ControlePessoaExternaModel, ControlePessoaExterna>().ReverseMap();
            CreateMap<EventoModel, Evento>()
                .ForMember(dest => dest.Processo, opt => opt.Ignore())  // Ignora o mapeamento do Processo
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())   // Ignora o mapeamento da Empresa
                .ReverseMap();

            CreateMap<EventoStatusPersonalizado, EventoStatusPersonalizadoModel>()
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ProcessoStatusPersonalizado, ProcessoStatusPersonalizadoModel>()
                .ForMember(dest => dest.Empresa, opt => opt.Ignore())
                .ReverseMap();

        }
    }
}
