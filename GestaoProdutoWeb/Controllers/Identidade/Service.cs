using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GestaoProduto.API.Controllers.Identidade
{
    public abstract class Service
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        } 

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrorResponse(HttpResponseMessage response)
        {
            switch((int)response.StatusCode)
            {
                case 401: //nao conhece usuario
                case 403: // acesso negado
                case 404: // recurso nao encontrado
                case 500: // erro servidor
                    throw new CustomHttpRequestException(response.StatusCode);

                case 400:
                    return false;
            }
            
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
