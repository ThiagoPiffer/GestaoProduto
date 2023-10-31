namespace GestaoProduto.Compartilhado.Model._Endereco
{
    public class EnderecoModel 
    {
        public int Id { get; set; }

        public string Numero { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
