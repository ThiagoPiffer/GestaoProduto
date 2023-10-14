namespace GestaoProduto.API
{
    public class AppSettings
    {
        public string AutenticacaoUrl { get; set; } = string.Empty;
        public string CatalogoUrl { get; set; } = string.Empty;
        public string Secret { get; set; }
        public int ExpiracaoHoras { get; set; }
        public string Emissor { get; set; }
        public string ValidoEm { get; set; }
    }
}
