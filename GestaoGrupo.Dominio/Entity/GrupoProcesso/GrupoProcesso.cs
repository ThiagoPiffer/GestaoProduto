﻿using GestaoProduto.Dominio._Base;

namespace GestaoProduto.Dominio.Entity
{
    public class GrupoProcesso : Entidade
    {
        public GrupoProcesso() { }

        public string Nome { get; set; }
        public int Posicao { get; set; }
    }
}
