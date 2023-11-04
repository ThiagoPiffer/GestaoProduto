﻿using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Empresa;

namespace GestaoProduto.Dominio.Entity._ProcessoStatusPersonalizado
{
    public class EventoStatusPersonalizado : Entidade
    {
        public EventoStatusPersonalizado() { }

        public string Nome { get; set; }
        public string? Descricao { get; set; }
        public string? MensagemNotificacao { get; set; }
        public bool ValidaCondicao { get; set; }
        public bool MaiorQue { get; set; }
        public bool MenorQue { get; set; }
        public bool IgualA { get; set; }
        public DateTime? DataControle { get; set; }
        public string Cor { get; set; }
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}


