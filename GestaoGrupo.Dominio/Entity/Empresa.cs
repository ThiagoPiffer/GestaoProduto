using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity._Empresa
{
    public class Empresa: Entidade
    {
        public Empresa() { }

        public string Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? CodigoIdentificador { get; set; }
    }
}
