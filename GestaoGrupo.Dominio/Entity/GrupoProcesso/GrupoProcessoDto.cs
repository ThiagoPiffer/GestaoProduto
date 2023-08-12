using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class GrupoProcessoDto
    {
        public GrupoProcessoDto() { }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int Posicao { get; set; }

        public bool Ativo { get; set; }
    }
}
