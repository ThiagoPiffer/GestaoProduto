using GestaoProduto.Dominio._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Entity._Endereco
{
    public class Endereco : Entidade
    {
        public Endereco() { }

        public string Numero{ get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
