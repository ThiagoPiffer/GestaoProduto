using GestaoProduto.Dominio.Model._Identidade;
using GestaoProduto.Dominio.IServico._Identidade;
using Microsoft.Extensions.Options;
using System.Text.Json;


namespace GestaoProduto.API.Controllers.Identidade
{
    public class IdentidadeServico : Service, IIdentidadeServico
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _settings;

        public IdentidadeServico(HttpClient httpClient,
                                 IOptions<AppSettings> settings)
        {
            //httpClient.BaseAddress = new Uri(_settings.Value.AutenticacaoUrl);
            _httpClient=httpClient;
            _settings=settings.Value;

        }

        public async Task<UsuarioRespostaLoginModel> Login(UsuarioLoginModel usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var _settings3 = _settings;

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
