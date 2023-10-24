using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Model._Identidade
{
    public class UsuarioRegistroModel
    {
        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string SenhaConfirmacao { get; set; } = string.Empty;
    }
}
