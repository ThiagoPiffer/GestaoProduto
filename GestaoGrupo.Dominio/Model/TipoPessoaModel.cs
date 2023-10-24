using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Model._TipoPessoa
{
    public class TipoPessoaModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public int IdEmpresa { get; set; }
    }
}
