using Microsoft.AspNetCore.Http;

namespace GestaoProduto.Dominio.Model._ArquivoProcessoTemplate
{
    public class ArquivoProcessoTemplateModel
    {
        public int Id { get; set; } = 0;
        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public IFormFile Arquivo { get; set; }
        public int EmpresaId { get; set; }
    }
}
