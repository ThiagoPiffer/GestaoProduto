using GestaoProduto.Compartilhado.Model._Endereco;

namespace GestaoProduto.Compartilhado.Model._PessoaProcesso
{
    public class PessoaProcessoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string? DataNascimento { get; set; } = string.Empty;
        public int? Idade { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string CPFCNPJ { get; set; } = string.Empty;
        public string Identidade { get; set; } = string.Empty;
        public string? DDDTelefone { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        public string? DDDCelular { get; set; } = string.Empty;
        public string? Celular { get; set; } = string.Empty;
        public int idTipoPessoa { get; set; }
        public string? TipoPessoaDescricao { get; set; } = string.Empty;
        public bool Ativo { get; set; }


        public string? Nacionalidade { get; set; }
        public string? Profissao { get; set; }
        public string? EstadoCivil { get; set; }
        public EnderecoModel? Endereco { get; set; }
    }
}
