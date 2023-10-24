using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Model._ArquivoProcesso
{
    public class ArquivoProcessoModel
    {
        public ArquivoProcessoModel() { }
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public string ExtensaoArquivo { get; set; }
        public string? Descricao { get; set; } // Uma descrição ou nota sobre o arquivo
        public long TamanhoArquivo { get; set; } 
        public int ProcessoId { get; set; }
        public string CaminhoArquivo { get; set; }
        //public string CaminhoArquivo { get; set; } 
        //public int UsuarioUploadId { get; set; } 
    }

}
