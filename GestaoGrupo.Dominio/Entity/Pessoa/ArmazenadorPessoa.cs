using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Dominio.Entity
{
    public class ArmazenadorPessoa
    {
        public readonly IPessoaRepositorio _pessoaRepositorio;
        public ArmazenadorPessoa(IPessoaRepositorio pessoaRepositorio)
        {
            _pessoaRepositorio = pessoaRepositorio;
        }

        public void Armazenar(PessoaDto pessoaDto)
        {
            var pessoaComMesmoCNPJ = _pessoaRepositorio.ObterPeloCNPJ(pessoaDto.CPFCNPJ);
            var pessoaComMesmoEmail = _pessoaRepositorio.ObterPorEmail(pessoaDto.Email);

            ValidadorDeRegra.Novo()
                .Quando(pessoaComMesmoCNPJ != null && pessoaComMesmoCNPJ.Id != pessoaDto.Id, ChaveTextos.PessoaCNPJJaCadastrado)
                .Quando(pessoaComMesmoEmail != null && pessoaComMesmoEmail.Id != pessoaDto.Id, ChaveTextos.PessoaEmailJaCadastrado)
                .DispararExcecaoSeExistir();

            //if (pessoaDto.Id == 0)
            //{
            //    var pessoa = new Pessoa(pessoaDto.Descricao, pessoaDto.CNPJ, pessoaDto.Ativo);
            //    _pessoaRepositorio.Adicionar(pessoa);
            //}
            //else
            //{
            //    var pessoa = _pessoaRepositorio.ObterPorId(pessoaDto.Id);
            //    pessoa.AlterarDescricao(pessoaDto.Descricao);
            //    pessoa.AlterarCNPJ(pessoaDto.CNPJ);
            //}
        }

        public void Editar(PessoaDto pessoaDto)
        {
            ValidadorDeRegra.Novo()
                .Quando(_pessoaRepositorio.ContemDuplicidadeCNPJ(pessoaDto), ChaveTextos.CNPJJaCadastrado)
                .DispararExcecaoSeExistir();

            //if (pessoaDto.Id != 0)
            //{
            //    var pessoa = _pessoaRepositorio.ObterPorId(pessoaDto.Id);
            //    pessoa.AlterarDescricao(pessoaDto.Descricao);
            //    pessoa.AlterarCNPJ(pessoaDto.CNPJ);
            //    pessoa.AlterarAtivo(pessoaDto.Ativo);
            //}
        }

        public void Deletar(PessoaDto pessoaDto)
        {
            if (pessoaDto.Id != 0)
            {
                var pessoa = _pessoaRepositorio.ObterPorIdAsync(pessoaDto.Id);
                //pessoa.Ativo = false;
            }
        }
    }
}
