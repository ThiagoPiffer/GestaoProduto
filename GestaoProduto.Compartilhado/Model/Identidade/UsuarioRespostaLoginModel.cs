namespace GestaoProduto.Compartilhado.Model._Identidade
{
    public class UsuarioRespostaLoginModel
    {
        public string AccessToken { get; set; } = string.Empty;
        public double ExpiresIn { get; set; } = 0.0;
        public UsuarioTokenModel UsuarioToken { get; set; } = null!;
        public ResponseResult responseResult { get; set; } = null!;
    }
} 