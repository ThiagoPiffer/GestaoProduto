namespace GestaoProduto.Dominio.Entity
{
    public class FornecedorDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string CNPJ { get; set; }
        public bool Ativo { get; set; }
    }
}
