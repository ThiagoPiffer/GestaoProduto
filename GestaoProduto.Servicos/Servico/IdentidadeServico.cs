using Azure;
using GestaoProduto.Compartilhado.Model._Identidade;
using GestaoProduto.Compartilhado.Interfaces.Servico._Identidade;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GestaoProduto.Dominio.Entity._Usuario;
using GestaoProduto.Dominio.Entity._Empresa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._IdentidadeCurrent;

namespace GestaoProduto.Servico._Identidade
{
    public class IdentidadeServico : Service, IIdentidadeServico
    {
        private readonly HttpClient _httpClient;
        //private readonly AppSettings _appSettings;

        public IdentidadeServico(
            HttpClient httpClient
            )
        {
            _httpClient=httpClient;
        }

        public async Task<UsuarioRespostaLoginModel> Login(UsuarioLoginModel usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            //AutenticacaoUrl
            var response = await _httpClient.PostAsync("https://localhost:7139/api/Identidade/LoginAutenticacao", loginContent);


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

            var response = await _httpClient.PostAsync("https://localhost:7139/api/Identidade/Registrar", registroContent);



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
