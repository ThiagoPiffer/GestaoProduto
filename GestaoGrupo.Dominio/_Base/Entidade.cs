namespace GestaoProduto.Dominio._Base
{
    public abstract class Entidade
    {
        public int Id { get; set; }
        public bool Ativo{ get; set; }
        public DateTime? DataCadastro { get; set; }
    }
}
