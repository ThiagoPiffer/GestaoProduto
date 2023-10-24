using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio.IRepositorio._Empresa;
using GestaoProduto.Dominio.IServico._Empresa;
using GestaoProduto.Dominio.Model._Empresa;

namespace GestaoProduto.Servico._Empresa
{
    public class EmpresaServico : IEmpresaServico
    {
        private readonly IRepositorio<Empresa> _repositorio;
        private readonly IEmpresaRepositorio _empresaRepositorio;
        private readonly IMapper _mapper;

        public EmpresaServico(IRepositorio<Empresa> repositorio,
                                        IEmpresaRepositorio empresaRepositorio,
                                        IMapper mapper)
        {
            _repositorio = repositorio;
            _empresaRepositorio = empresaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<Empresa>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<Empresa>>(listaObj);
            return listaObj;
        }

        public async Task<EmpresaModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<EmpresaModel>(Obj);
            
            return objModel;
        }

        public async Task<List<Empresa>> BuscaPorTermo(string termo)
        {
            List<Empresa> lista = await _empresaRepositorio.BuscaPorTermo(termo);            
            return lista;
        }

        public async Task<Empresa> Adicionar(EmpresaModel model)
        {            
            var obj = _mapper.Map<Empresa>(model);                
            await _empresaRepositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<Empresa> Editar(EmpresaModel model)
        {            
            var obj = _mapper.Map<Empresa>(model);
            await _empresaRepositorio.EditarAsync(obj);

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
