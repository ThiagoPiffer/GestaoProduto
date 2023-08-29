using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity;
using GestaoProduto.Dominio.Repositorio;
using GestaoProduto.Dominio.Servico;
using GestaoProduto.Dominio.Model;

namespace GestaoProduto.Servico
{
    public class ArquivoProcessoServico : IArquivoProcessoServico
    {
        private readonly IRepositorio<ArquivoProcesso> _repositorio;
        private readonly IArquivoProcessoRepositorio _arquivoProcessoRepositorio;
        private readonly IMapper _mapper;

        public ArquivoProcessoServico(IRepositorio<ArquivoProcesso> repositorio,
                                      IArquivoProcessoRepositorio arquivoProcessoRepositorio,
                                      IMapper mapper)
        {
            _repositorio = repositorio;
            _arquivoProcessoRepositorio = arquivoProcessoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ArquivoProcessoModel>> Listar()
        {
            var listaArquivoProcessos = await _repositorio.ObterListaAsync();
            var mappedArquivoProcessos = _mapper.Map<List<ArquivoProcessoModel>>(listaArquivoProcessos);
            return mappedArquivoProcessos;
        }

        public async Task<List<ArquivoProcessoModel>> ListarArquivosProcesso(int idProcesso)
        {
            var listaArquivosProcesso = await _arquivoProcessoRepositorio.ListarArquivosProcesso(idProcesso);
            var listaArquivosProcessoModel = _mapper.Map<List<ArquivoProcessoModel>>(listaArquivosProcesso);
            return listaArquivosProcessoModel;
        }

        public async Task<ArquivoProcessoModel> ObterPorId(int id)
        {
            var arquivoProcesso = await _repositorio.ObterPorIdAsync(id);
            var arquivoProcessoModel = _mapper.Map<ArquivoProcessoModel>(arquivoProcesso);

            return arquivoProcessoModel;
        }


        public async Task<ArquivoProcesso> Adicionar(ArquivoProcessoModel arquivoProcessoModel, Stream fileStream)
        {
            var arquivoProcesso = _mapper.Map<ArquivoProcesso>(arquivoProcessoModel);

            // Defina o ID do usuário como 1 (por enquanto)
            int idUsuario = 1;
            string pathBase = Path.Combine("Arquivos", $"folder_{idUsuario}", $"folder_{arquivoProcessoModel.ProcessoId}");

            // Verifique se o diretório existe; se não, crie-o
            if (!Directory.Exists(pathBase))
            {
                Directory.CreateDirectory(pathBase);
            }

            string fullPath = Path.Combine(pathBase, arquivoProcessoModel.NomeArquivo);
            arquivoProcesso.CaminhoArquivo = fullPath;

            // Salve o arquivo
            using (var file = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                await fileStream.CopyToAsync(file);
            }

            await _repositorio.AdicionarAsync(arquivoProcesso);

            return arquivoProcesso;
        }

        public async Task<ArquivoProcesso> Editar(ArquivoProcessoModel arquivoProcessoModel)
        {

            var arquivoProcesso = _mapper.Map<ArquivoProcesso>(arquivoProcessoModel);
            await _repositorio.EditarAsync(arquivoProcesso);

            return arquivoProcesso;
        }

        public async Task<ArquivoProcesso> EditarDescricao(int id, string descricao)
        {            
            var arquivoProcesso = await _arquivoProcessoRepositorio.ObterPorIdAsync(id);
            arquivoProcesso.Descricao = descricao;
            await _repositorio.EditarAsync(arquivoProcesso);

            return arquivoProcesso;
        }

        public async Task<string> Delete(int id)
        {
            var arquivoProcesso = await _repositorio.ObterPorIdAsync(id);
            await _repositorio.ExcluirAsync(arquivoProcesso);

            return "Excluído com sucesso";
        }
    }
}
