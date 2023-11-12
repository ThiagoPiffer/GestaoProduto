using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Compartilhado.Model._ProcessoStatusPersonalizado;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Servico._ProcessoStatusPersonalizado;
using GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado;

namespace GestaoProduto.Servico._ProcessoStatusPersonalizado
{
    public class ProcessoStatusPersonalizadoServico : IProcessoStatusPersonalizadoServico
    {
        private readonly IRepositorio<ProcessoStatusPersonalizado> _repositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public ProcessoStatusPersonalizadoServico(IRepositorio<ProcessoStatusPersonalizado> repositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _mapper = mapper;
            _user = user;
        }   
        
        public async Task<List<ProcessoStatusPersonalizado>> Listar()
        {
            var empresa = _user.EmpresaCurrent;
            var lista = await _repositorio.ObterListaFiltroAsync(o => o.EmpresaId == empresa.Id); 
            return lista.ToList();
        }

        public async Task<ProcessoStatusPersonalizadoModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<ProcessoStatusPersonalizadoModel>(Obj);

            return objModel;
        }

        public async Task<ProcessoStatusPersonalizado> Adicionar(ProcessoStatusPersonalizadoModel model)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            model.EmpresaId = empresaId;

            var obj = _mapper.Map<ProcessoStatusPersonalizado>(model);
            await _repositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task AdicionarStatusPadraoProcesso()
        {
            var lista = await Listar();

            if (lista.Count() == 0)
            {

                var empresaId = _user.EmpresaCurrent.Id; // Valor fixo conforme solicitado

                var defaultStatuses = new List<ProcessoStatusPersonalizado>
                {                
                    new ProcessoStatusPersonalizado { Nome = "Normal", Descricao = "Processo com prazos em dia", ValidaCondicao = true, MenorQue = true, ValorControle = -10, Cor = "#83d400", EmpresaId = empresaId, Icone = "pi pi-check-square" },
                    new ProcessoStatusPersonalizado { Nome = "Normal", Descricao = "Processo com menos de 10 dias para vencimento", ValidaCondicao = true, MenorQue = true, ValorControle = -5, Cor = "#8bf500", EmpresaId = empresaId, Icone = "pi pi-exclamation-triangle" },
                    new ProcessoStatusPersonalizado { Nome = "Alerta", Descricao = "Processo vencerá nos próximos 5 dias", ValidaCondicao = true, MenorQue = true, ValorControle = 0, Cor = "#ffe100", EmpresaId = empresaId, Icone = "pi pi-exclamation-triangle" },
                    new ProcessoStatusPersonalizado { Nome = "Vencerá", Descricao = "Processo vencerá hoje.", ValidaCondicao = true, IgualA = true, ValorControle = 0, Cor = "#c93838", EmpresaId = empresaId, Icone = "pi pi-question-circle" },
                    new ProcessoStatusPersonalizado { Nome = "Processo vencido", Descricao = "Processo venceu a mais de 1 dia", ValidaCondicao = true, MaiorQue = true, ValorControle = 1, Cor = "#ff0808", EmpresaId = empresaId, Icone = "pi pi-question-circle" },
                };

                await _repositorio.AdicionarListaAsync(defaultStatuses);
            }
            else
            {                
                throw new ExcecaoDeDominio( new List<string> { "Não é permitido gerar Status padrão no momento" } );
            }
        }

        public async Task<ProcessoStatusPersonalizado> Editar(ProcessoStatusPersonalizadoModel model)
        {
            var obj = _mapper.Map<ProcessoStatusPersonalizado>(model);
            await _repositorio.EditarAsync(obj);

            return obj;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }
    }
}