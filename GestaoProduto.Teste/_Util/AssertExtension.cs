﻿using GestaoProduto.Dominio._Base;
using Xunit;

namespace GestaoProduto.Teste._Util
{
    public static class AssertExtension
    {
        public static void ComMensagem(this ExcecaoDeDominio exception, string mensagem)
        {
            if(exception.MensagensDeErro.Contains(mensagem))
                Assert.True(true);
            else
                Assert.False(true, $"Esperava a mensagem '{mensagem}'");
        }
    }
}
