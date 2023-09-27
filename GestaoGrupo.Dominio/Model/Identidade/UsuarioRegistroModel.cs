using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Model.Identidade
{
    public class UsuarioRegistroModel
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string SenheConfirmacao { get; set; }
    }
}
