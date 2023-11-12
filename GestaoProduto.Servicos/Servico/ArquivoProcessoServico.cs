using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ArquivoProcesso;
using GestaoProduto.Compartilhado.Model._ArquivoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Servico._ArquivoProcesso;
using GestaoProduto.Dominio.Entity._ArquivoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Servico._Usuario;

namespace GestaoProduto.Servico._ArquivoProcesso
{
    public class ArquivoProcessoServico : IArquivoProcessoServico
    {
        private readonly IRepositorio<ArquivoProcesso> _repositorio;
        private readonly IArquivoProcessoRepositorio _arquivoProcessoRepositorio;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IMapper _mapper;

        public ArquivoProcessoServico(IRepositorio<ArquivoProcesso> repositorio,
                                      IArquivoProcessoRepositorio arquivoProcessoRepositorio,
                                      IUsuarioServico usuarioServico,
                                      IMapper mapper)
        {
            _repositorio = repositorio;
            _arquivoProcessoRepositorio = arquivoProcessoRepositorio;
            _usuarioServico = usuarioServico;
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
            var usuario = _usuarioServico.UsuarioCurrent();
            int idUsuario =  usuario.Id;
            int idEmpresa = usuario.EmpresaId;
            string pathBase = Path.Combine("Arquivos", $"folderEmpresa_{idEmpresa}", $"folderUsuario_{idUsuario}", $"folderProcesso_{arquivoProcessoModel.ProcessoId}");

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

            if (arquivoProcesso == null)
            {
                return "Arquivo não encontrado";
            }

            // Caminho completo do arquivo
            var caminhoCompleto = Path.Combine(Directory.GetCurrentDirectory(), arquivoProcesso.CaminhoArquivo);

            // Verifica se o arquivo existe antes de tentar excluí-lo
            if (File.Exists(caminhoCompleto))
            {
                try
                {
                    // Exclui o arquivo físico
                    File.Delete(caminhoCompleto);
                }
                catch (Exception ex) // Captura a exceção para tratamento de erros
                {
                    // Aqui você pode logar o erro ou retornar uma mensagem específica
                    // Por exemplo, se você estiver usando um logger, poderia ser algo como:
                    // _logger.LogError("Ocorreu um erro ao tentar excluir o arquivo: {ex}", ex);
                    return "Não foi possível excluir o arquivo físico: " + ex.Message;
                }
            }
            else
            {
                return "Arquivo não encontrado no sistema de arquivos";
            }

            // Após a exclusão do arquivo físico, exclui a entrada no banco de dados
            await _repositorio.ExcluirAsync(arquivoProcesso);

            return "Excluído com sucesso";
        }
    }
}
