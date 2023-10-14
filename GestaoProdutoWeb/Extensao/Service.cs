using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Servico
{
    public abstract class Service
    {
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
