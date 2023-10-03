using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Model.Identidade
{
    public class UsuarioTokenModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<UsuarioClaimModel> Claims { get; set; } = new List<UsuarioClaimModel>(); 
    }
}
