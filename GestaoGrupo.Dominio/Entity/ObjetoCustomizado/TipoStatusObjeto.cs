using Google.Apis.Util;

namespace GestaoProduto.Dominio.Entity
{
    public enum TipoStatusObjeto
    {
        [StringValue("N")]
        Normal,

        [StringValue("A")]
        Atencao,

        [StringValue("AL")]
        Alerta
    }
}
