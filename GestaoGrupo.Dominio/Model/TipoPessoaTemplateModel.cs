namespace GestaoProduto.Dominio.Model._TipoPessoaTemplate
{
    public class TipoPessoaTemplateModel
    {
        public int Id { get; set; }
        public int IdTipoPessoa { get; set; }
        public int IdArquivoProcessoTemplate { get; set; }
        public string CampoChave { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public string Descricao { get; set; } = string.Empty;
    }
}


/*
ampoChave "111"
id 0
idArquivoProcessoTemplate 0
idEmpresa 2
idProcesso 0
idTipoPessoa 1
*/