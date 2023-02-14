using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Fornecedores
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
    }
}
