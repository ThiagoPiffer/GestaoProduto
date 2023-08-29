namespace GestaoProduto.Dominio.Entity
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }      
        public string Email { get; set; } = string.Empty;
        public string CPFCNPJ { get; set; } = string.Empty;
        public string DDDTelefone { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string DDDCelular { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public Boolean Ativo { get; set; }
    }
}
