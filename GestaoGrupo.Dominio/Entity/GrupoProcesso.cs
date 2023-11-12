using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoProduto.Dominio.Entity._GrupoProcesso
{
    public class GrupoProcesso : Entidade
    {
        public GrupoProcesso() { }

        public string Nome { get; set; }
        public int Posicao { get; set; }
        public int EmpresaId { get; set; } 
        public Empresa Empresa { get; set; }
    }
}
