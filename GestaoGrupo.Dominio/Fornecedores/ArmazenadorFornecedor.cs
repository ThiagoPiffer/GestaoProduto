using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestaoProduto.Dominio.Fornecedores
{  
    public class ArmazenadorFornecedor
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;        

        public ArmazenadorFornecedor(IFornecedorRepositorio fornecedorRepositorio)
        {
            _fornecedorRepositorio = fornecedorRepositorio;            
        }       

        public void Armazenar(FornecedorDto fornecedorDto)
        {
            var fornecedorComMesmoCNPJ = _fornecedorRepositorio.ObterPeloCNPJ(fornecedorDto.CNPJ);

            ValidadorDeRegra.Novo()
                .Quando(fornecedorComMesmoCNPJ != null && fornecedorComMesmoCNPJ.Id != fornecedorDto.Id, ChaveTextos.CNPJJaCadastrado)
                .DispararExcecaoSeExistir();

            if (fornecedorDto.Id == 0)
            {                
                var fornecedor = new Fornecedor(fornecedorDto.Descricao, fornecedorDto.CNPJ, fornecedorDto.Ativo);
                _fornecedorRepositorio.Adicionar(fornecedor);
            }
            else
            {
                var fornecedor = _fornecedorRepositorio.ObterPorId(fornecedorDto.Id);
                fornecedor.AlterarDescricao(fornecedorDto.Descricao);
                fornecedor.AlterarCNPJ(fornecedorDto.CNPJ);
            }            
        }

        public void Editar(FornecedorDto fornecedorDto)
        { 
            if (fornecedorDto.Id != 0)
            {
                var fornecedor = _fornecedorRepositorio.ObterPorId(fornecedorDto.Id);
                fornecedor.AlterarDescricao(fornecedorDto.Descricao);
                fornecedor.AlterarCNPJ(fornecedorDto.CNPJ);
            }            
        }

        public void Deletar(FornecedorDto fornecedorDto)
        {
            if (fornecedorDto.Id != 0)
            {
                var fornecedor = _fornecedorRepositorio.ObterPorId(fornecedorDto.Id);
                fornecedor.AlterarAtivo(false);
            }
        }
    }
}
