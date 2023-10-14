using Azure;
using GestaoProduto.Dominio.Model.Identidade;
using GestaoProduto.Dominio.Servico;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


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

            var response = await _httpClient.PostAsync($"{_settings}/api/Identidade/Login", loginContent);


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

            var response = await _httpClient.PostAsync($"{_settings}/api/Identidade/Registrar", registroContent);



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
