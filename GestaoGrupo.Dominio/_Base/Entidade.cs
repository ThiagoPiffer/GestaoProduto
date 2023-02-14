namespace GestaoProduto.Dominio._Base
{
    public abstract class Entidade
    {
        public int Id { get; protected set; }
        public bool Ativo{ get; protected set; }
    }
}
