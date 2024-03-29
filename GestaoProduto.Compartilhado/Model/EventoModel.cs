﻿using GestaoProduto.Compartilhado.Model._Empresa;
using GestaoProduto.Compartilhado.Model._EventoStatusPersonalizado;
using GestaoProduto.Compartilhado.Model._Processo;

namespace GestaoProduto.Compartilhado.Model._Evento
{
    public class EventoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataFinal { get; set; }
        public bool Encerrado { get; set; }
        public int ProcessoId { get; set; }
        public virtual ProcessoModel? Processo { get; set; } = null;
        public int EmpresaId { get; set; }
        public virtual EmpresaModel? Empresa { get; set; } = null;
        public EventoStatusPersonalizadoModel? EventoStatusPersonalizadoModel { get; set; }
    }
}
