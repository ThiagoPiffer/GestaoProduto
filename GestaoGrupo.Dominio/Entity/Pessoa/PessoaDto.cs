namespace GestaoProduto.Dominio.Entity
{
    public class PessoaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string CPFCNPJ { get; set; }
        public string DDDTelefone { get; set; }
        public string Telefone { get; set; }
        public string DDDCelular { get; set; }
        public string Celular { get; set; }
    }
}
