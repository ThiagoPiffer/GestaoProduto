using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces.Servico._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Model._ControlePessoaExterna;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Servico._ControlePessoaExterna
{
    public class ControlePessoaExternaServico : IControlePessoaExternaServico
    {
        private readonly IRepositorio<ControlePessoaExterna> _repositorio;
        private readonly IRepositorio<Empresa> _repositorioEmpresa;
        private readonly IControlePessoaExternaRepositorio _controlePessoaExternaRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public ControlePessoaExternaServico(IRepositorio<ControlePessoaExterna> repositorio,
                                        IRepositorio<Empresa> repositorioEmpresa,
                                        IControlePessoaExternaRepositorio controlePessoaExternaRepositorio,
                                        IMapper mapper,
                                        IUser user)
        {
            _repositorio = repositorio;
            _repositorioEmpresa = repositorioEmpresa;
            _controlePessoaExternaRepositorio = controlePessoaExternaRepositorio;
            _mapper = mapper;
            _user = user;
        }

        public async Task<List<ControlePessoaExterna>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<ControlePessoaExterna>>(listaObj);
            return listaObj;
        }

        public async Task<ControlePessoaExternaModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<ControlePessoaExternaModel>(Obj);

            return objModel;
        }

        public async Task<ControlePessoaExterna> Adicionar(string dataExpiracao)
        {
            var  obj = new ControlePessoaExterna();
            obj.IdUrl = Guid.NewGuid();
            obj.Url = $"http://localhost:4200/cadastro-pessoa-externa/{obj.IdUrl}";
            obj.EmpresaId = _user.EmpresaCurrent.Id;
            obj.Expiracao = Convert.ToDateTime(dataExpiracao);
            await _repositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<ControlePessoaExterna> Editar(ControlePessoaExternaModel model)
        {
            var obj = _mapper.Map<ControlePessoaExterna>(model);
            await _repositorio.EditarAsync(obj);

            return obj;
        }

        public async Task<string> Delete(int id)
        {
            var obj = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(obj);

            return "Excluído com sucesso";
        }

        public async Task<ControlePessoaExternaModel> Validar(string id)
        {
            var resultControlePessoaExterna = await _repositorio.
                ObterListaFiltroAsync(o => o.IdUrl.ToString().ToUpper() == id.ToUpper() &&
                                                    o.Expiracao > DateTime.Now);            
            
            var obj = resultControlePessoaExterna.FirstOrDefault();

            var empresaId = obj!.EmpresaId;

            var resultEmpresa = await _repositorioEmpresa.ObterListaFiltroAsync(o => o.Id == obj!.EmpresaId);
            obj!.Empresa = resultEmpresa.FirstOrDefault()!;
            
            if (obj == null) throw new ExcecaoDeDominio(new List<string> { "Chave inexistente" });            

            var controlePessoaExterna = _mapper.Map<ControlePessoaExternaModel>(obj);
            return controlePessoaExterna;
        }

        public class NotFoundException : Exception
        {
            public NotFoundException(string v) : base("Chave não encontrada") { }
        }
    }
}