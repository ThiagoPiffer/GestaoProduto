using GestaoProduto.Compartilhado.Model._Identidade;
using GestaoProduto.Compartilhado.Interfaces.Servico._Identidade;
using Microsoft.Extensions.Options;
using System.Text.Json;
using GestaoProduto.Compartilhado.Interfaces.Servico._Empresa;
using GestaoProduto.Servico._Empresa;
using AutoMapper;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._PessoaProcesso;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Servico._Usuario;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Usuario;

namespace GestaoProduto.API.Controllers.Identidade
{
    public class IdentidadeServico : Service, IIdentidadeServico
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;
        private readonly IRepositorio<Empresa> _repositorioEmpresa;
        private readonly IUsuarioRepositorio _repositorioUsuario;
        private readonly IMapper _mapper;

        public IdentidadeServico(
            HttpClient httpClient,
            IOptions<AppSettings> settings,
            IRepositorio<Empresa> repositorioEmpresa,
            IUsuarioRepositorio repositorioUsuario,
            IMapper mapper)
        {
            //httpClient.BaseAddress = new Uri(_settings.Value.AutenticacaoUrl);
            _httpClient=httpClient;
            _settings=settings.Value;
            _repositorioEmpresa=repositorioEmpresa;
            _repositorioUsuario=repositorioUsuario;
            _mapper = mapper;
        }

        public async Task<UsuarioRespostaLoginModel> Login(UsuarioLoginModel usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);       

            var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}/apiIdentidade/Identidade/LoginAutenticacao", loginContent);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (!TratarErrorResponse(response))
            {
                return new UsuarioRespostaLoginModel
                {
                    responseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginModel>(response);
        }

        public async Task<UsuarioRespostaLoginModel> Registro(UsuarioRegistroModel usuarioRegistroModel)
        {
            var registroContent = ObterConteudo(usuarioRegistroModel);

            var response = await _httpClient.PostAsync($"{_settings.AutenticacaoUrl}/apiIdentidade/Identidade/Registrar", registroContent);

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                try
                {
                    var idUsuarioAspNet = _repositorioUsuario.BuscaIdUsuarioAspNet(usuarioRegistroModel.Email);

                    var empresa = _mapper.Map<Empresa>(usuarioRegistroModel.EmpresaModel);
                    await _repositorioEmpresa.AdicionarAsync(empresa);

                    var usuario = new Usuario();
                    usuario.Nome = usuarioRegistroModel.Nome;
                    usuario.CPF = usuarioRegistroModel.CPF;
                    usuario.EmpresaId = empresa.Id;
                    usuario.AspNetUserId = idUsuarioAspNet;

                    await _repositorioUsuario.Armazenar(usuario);

                    //caso algo de errado ao salvar dados ira apagar os dados salvos
                    if (empresa.Id == 0 || usuario.Id == 0)
                        throw new Exception("Cadastro Invalido.");
                }
                catch (Exception ex)
                {
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;                    

                    var empresa = _repositorioEmpresa.ObterListaFiltroAsync(e => e.CNPJ == usuarioRegistroModel.EmpresaModel.CNPJ).Result.FirstOrDefault();
                    if (empresa != null)
                    {
                        _repositorioEmpresa.DetachAllInstancesOfEntity(empresa.Id); // Adicione este método ao seu repositório.                        // Adicione um método 'Detach' ao seu repositório se ainda não tiver um.
                        await _repositorioEmpresa.ExcluirAsync(empresa);
                    }

                    var idUsuarioAspNet = _repositorioUsuario.BuscaIdUsuarioAspNet(usuarioRegistroModel.Email);
                    _repositorioUsuario.DeletarIdUsuarioAspNet(idUsuarioAspNet);

                }
            }


            if (!TratarErrorResponse(response))
            {
                return new UsuarioRespostaLoginModel
                {
                    responseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }

            return await DeserializarObjetoResponse<UsuarioRespostaLoginModel>(response);
        }
    }
}

