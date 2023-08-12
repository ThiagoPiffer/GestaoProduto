using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Dominio.Entity
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
                _fornecedorRepositorio.AdicionarAsync(fornecedor);
            }
            else
            {
                var fornecedor = _fornecedorRepositorio.ObterPorIdAsync(fornecedorDto.Id);
                //fornecedor.Descricao = fornecedorDto.Descricao;
                //fornecedor.CNPJ = Fornecedor.CNPJValido(fornecedorDto.CNPJ) ? fornecedorDto.CNPJ : fornecedor.CNPJ;
            }
        }

        public void Editar(FornecedorDto fornecedorDto)
        {
            ValidadorDeRegra.Novo()
                .Quando(_fornecedorRepositorio.ContemDuplicidadeCNPJ(fornecedorDto), ChaveTextos.CNPJJaCadastrado)
                .DispararExcecaoSeExistir();

            if (fornecedorDto.Id != 0)
            {
                var fornecedor = _fornecedorRepositorio.ObterPorIdAsync(fornecedorDto.Id);
                //fornecedor.Descricao = fornecedorDto.Descricao;
                //fornecedor.AlterarCNPJ(fornecedorDto.CNPJ);
                //fornecedor.AlterarAtivo(fornecedorDto.Ativo);
            }
        }

        public void Deletar(FornecedorDto fornecedorDto)
        {
            if (fornecedorDto.Id != 0)
            {
                var fornecedor = _fornecedorRepositorio.ObterPorIdAsync(fornecedorDto.Id);
                //fornecedor.AlterarAtivo(false);
            }
        }
    }
}
