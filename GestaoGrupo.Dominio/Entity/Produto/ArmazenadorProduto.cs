using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Repositorio;

namespace GestaoProduto.Dominio.Entity
{
    public class ArmazenadorProduto
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IFornecedorRepositorio _fornecedorRepositorio;

        public ArmazenadorProduto(IProdutoRepositorio produtoRepositorio,
                                  IFornecedorRepositorio fornecedorRepositorio
                                  )
        {
            _produtoRepositorio = produtoRepositorio;
            _fornecedorRepositorio = fornecedorRepositorio;
        }

        public void Armazenar(ProdutoDto produtoDto)
        {
            var existeDuplicidade = _produtoRepositorio.ContemDuplicidadeDescricao(produtoDto);

            ValidadorDeRegra.Novo()
                .Quando(existeDuplicidade, ChaveTextos.ProdutoJaCadastrado)
                //.Quando(_fornecedorRepositorio.ExisteCNPJ(produtoDto.Fornecedor.CNPJ), ChaveTextos.CNPJInexistente)
                .Quando(produtoDto.DataFabricacao >= produtoDto.DataValidade, ChaveTextos.DataFabricacaoMaiorQueDataValidade)
                .DispararExcecaoSeExistir();

            if (produtoDto.Id == 0)
            {
                var fornecedor = _fornecedorRepositorio.ObterPeloCNPJ(produtoDto.Fornecedor.CNPJ);

                var produto = new Produto(produtoDto.Descricao, produtoDto.DataFabricacao, produtoDto.DataValidade, fornecedor, produtoDto.Ativo);
                _produtoRepositorio.Adicionar(produto);
            }
            else
            {
                var produto = _produtoRepositorio.ObterPorId(produtoDto.Id);
                produto.AlterarDescricao(produtoDto.Descricao);
                produto.AlterarDataFabricacao(produtoDto.DataFabricacao);
                produto.AlterarDataValidade(produtoDto.DataValidade);
                produto.AlterarFornecedor(produto.Fornecedor);
            }
        }

        public void Editar(ProdutoDto produtoDto)
        {
            ValidadorDeRegra.Novo()
                .Quando(_produtoRepositorio.ObterLista().Where(p => p.Ativo && p.Descricao == produtoDto.Descricao && p.Id != produtoDto.Id).Count() > 0, ChaveTextos.ProdutoJaCadastrado)
                .Quando(_fornecedorRepositorio.ObterLista().Where(f => f.Ativo && f.CNPJ == produtoDto.Fornecedor.CNPJ).Count() == 0, ChaveTextos.CNPJInexistente)
                .Quando(produtoDto.DataFabricacao >= produtoDto.DataValidade, ChaveTextos.DataFabricacaoMaiorQueDataValidade)
                .DispararExcecaoSeExistir();

            if (produtoDto.Id != 0)
            {
                var produto = _produtoRepositorio.ObterPorId(produtoDto.Id);
                var fornecedor = _fornecedorRepositorio.ObterPeloCNPJ(produtoDto.Fornecedor.CNPJ);
                produto.AlterarDescricao(produtoDto.Descricao);
                produto.AlterarDataFabricacao(produtoDto.DataFabricacao);
                produto.AlterarDataValidade(produtoDto.DataValidade);
                produto.AlterarFornecedor(fornecedor);
            }
        }

        public void Deletar(ProdutoDto produtoDto)
        {
            if (produtoDto.Id != 0)
            {
                var produto = _produtoRepositorio.ObterPorId(produtoDto.Id);
                produto.AlterarAtivo(false);
            }
        }

        public List<Produto> BuscaPorTermo(string termo)
        {
            return _produtoRepositorio.BuscaPorTermo(termo);
        }
    }
}
