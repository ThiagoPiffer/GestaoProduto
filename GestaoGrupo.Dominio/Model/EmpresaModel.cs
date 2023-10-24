namespace GestaoProduto.Dominio.Model._Empresa
{
    public class EmpresaModel
    {
        public EmpresaModel() { }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string? CNPJ { get; set; }
        public string? CodigoIdentificador { get; set; }        
    }
}
