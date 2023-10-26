using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.IRepositorio._Usuario;
using GestaoProduto.Dominio.IServico._Usuario;
using GestaoProduto.Dominio.Model._Usuario;

namespace GestaoProduto.Servico._Usuario
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IRepositorio<Usuario> _repositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IMapper _mapper;

        public UsuarioServico(IRepositorio<Usuario> repositorio,
                                        IUsuarioRepositorio usuarioRepositorio,
                                        IMapper mapper)
        {
            _repositorio = repositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _mapper = mapper;
        }

        public async Task<List<Usuario>> Listar()
        {
            var listaObj = await _repositorio.ObterListaAsync();
            var x = _mapper.Map<List<Usuario>>(listaObj);
            return listaObj;
        }

        public async Task<UsuarioModel> ObterPorId(int id)
        {
            var Obj = await _repositorio.ObterPorIdAsync(id);
            var objModel = _mapper.Map<UsuarioModel>(Obj);

            return objModel;
        }

        public async Task<List<Usuario>> BuscaPorTermo(string termo)
        {
            List<Usuario> lista = await _usuarioRepositorio.BuscaPorTermo(termo);
            return lista;
        }

        public async Task<Usuario> Adicionar(UsuarioModel model)
        {
            var obj = _mapper.Map<Usuario>(model);
            obj.Empresa = null;
            await _repositorio.AdicionarAsync(obj);

            return obj;
        }

        public async Task<Usuario> Editar(UsuarioModel model)
        {
            var obj = _mapper.Map<Usuario>(model);
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
