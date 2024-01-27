using GestaoProduto.Dominio._Base;
using AutoMapper;
using GestaoProduto.Dominio.Entity._Pessoa;
using GestaoProduto.Dominio.Entity._PessoaProcesso;
using GestaoProduto.Compartilhado.Model._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Pessoa;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Processo;
using GestaoProduto.Compartilhado.Model._PessoaProcesso;
using GestaoProduto.Compartilhado.Interfaces.Servico._Pessoa;
using GestaoProduto.Compartilhado.Interfaces._User;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._ControlePessoaExterna;
using GestaoProduto.Dominio.Entity._ControlePessoaExterna;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._Endereco;
using GestaoProduto.Compartilhado.Model._Endereco;

namespace GestaoProduto.Servico_Pessoa
{
    public class PessoaServico : IPessoaServico
    {
        private readonly IRepositorio<Pessoa> _repositorio;
        private readonly IRepositorio<PessoaProcesso> _repositorioPessoaProcesso;
        private readonly IRepositorio<Endereco> _repositorioEndereco;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IProcessoRepositorio _processoRepositorio;
        private readonly IControlePessoaExternaRepositorio _controlePessoaExternaRepositorio;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public PessoaServico(IRepositorio<Pessoa> repositorio,
                             IRepositorio<PessoaProcesso> repositorioPessoasProcesso,
                             IRepositorio<Endereco> repositorioEndereco,
                             IPessoaRepositorio pessoaRepositorio,
                             IProcessoRepositorio processoRepositorio,
                             IControlePessoaExternaRepositorio controlePessoaExternaRepositorio,
                             IMapper mapper,
                             IUser user)
        {
            _repositorio = repositorio;
            _repositorioPessoaProcesso = repositorioPessoasProcesso;
            _repositorioEndereco = repositorioEndereco;
            _pessoaRepositorio = pessoaRepositorio;
            _processoRepositorio = processoRepositorio;
            _controlePessoaExternaRepositorio=controlePessoaExternaRepositorio;
            _mapper = mapper;
            _user=user;
        }

        public async Task<List<Pessoa>> Listar()
        {
            var listaPessoas = await _repositorio.ObterListaAsync();
            var mappedPessoas = _mapper.Map<List<Pessoa>>(listaPessoas);
            return mappedPessoas;
        }

        public async Task<List<PessoaProcessoModel>> ListarPessoasProcesso(int idProcesso)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var listaPessoas = await _pessoaRepositorio.ListarPessoasProcesso(idProcesso, empresaId);
            return listaPessoas;
        }

        public async Task<List<PessoaProcessoModel>> ListarPessoasCompleta()
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var listaPessoas = await _pessoaRepositorio.ListarPessoasProcesso(0, empresaId, false, true);
            return listaPessoas;
        }

        public async Task<List<PessoaProcessoModel>> listarPessoasAssociar(int idProcesso)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var listaPessoas = await _pessoaRepositorio.ListarPessoasProcesso(idProcesso, empresaId, false);
            return listaPessoas;
        }

        public async Task<List<PessoaProcessoModel>> listarPessoasExterna()
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var result = await _pessoaRepositorio
                .ObterListaFiltroAsync(p => p.CadastroExterno &&
                                                     p.EmpresaId == empresaId
                );

            var mappedPessoas = _mapper.Map<List<PessoaProcessoModel>>(result);
            return mappedPessoas;
        }

        public async Task<PessoaModel> ObterPorId(int id)
        {
            var pessoa = await _repositorio.ObterPorIdAsync(id);
            var pessoaModel = _mapper.Map<PessoaModel>(pessoa);

            if (pessoa.EnderecoId.HasValue)
            {
                var endereco = _mapper.Map<EnderecoModel>(await _repositorioEndereco.ObterPorIdAsync(pessoa.EnderecoId.Value));
                pessoaModel.Endereco = endereco;
            }

            return pessoaModel;
        }

        public async Task<Pessoa> Adicionar(PessoaModel pessoaModel)
        {
            var enderecoModel = pessoaModel.Endereco;
            pessoaModel.Endereco = null;
            pessoaModel.EmpresaId = _user.EmpresaCurrent.Id;

            //adiciona primeiro a pessoa para obter o id do banco
            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            pessoa.EmpresaId = _user.EmpresaCurrent.Id;
            pessoa = await _pessoaRepositorio.AdicionarAsyncSaveChanges(pessoa);

            if (enderecoModel != null)
            {
                var endereco = _mapper.Map<Endereco>(enderecoModel);
                endereco = await _repositorioEndereco.AdicionarAsyncSaveChanges(endereco);

                pessoa.Endereco = endereco;
                pessoa = await _pessoaRepositorio.EditarAsync(pessoa);
            }            

            return pessoa;
        }

        protected async Task<PessoaProcesso> AssociarPessoaProcesso(int idProcesso, int pessoaId)
        {
            try
            {
                var pessoasProcesso = new PessoaProcesso();
                pessoasProcesso.ProcessoId = idProcesso;
                pessoasProcesso.PessoaId = pessoaId;
                pessoasProcesso.Ativo = true;

                await _repositorioPessoaProcesso.AdicionarAsyncSaveChanges(pessoasProcesso);
                return pessoasProcesso;
            }catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<PessoaProcesso> Associar(PessoaProcessoModel pessoaModel, int idProcesso)
        {
            var pessoa = _mapper.Map<Pessoa>(pessoaModel);
            //salva pessoa processo com o id adiquirido do banco apos salvar
            var result = AssociarPessoaProcesso(idProcesso, pessoa.Id);
            //var pessoaProcesso = result.Result;                       

            return result.Result;
        }

        public async Task<Pessoa> AdicionarCadastroExterno(PessoaModel pessoaModel)
        {
            var controlePessoaExterna = _controlePessoaExternaRepositorio.ObterPorIdAsync(pessoaModel.ControlePessoaExternaId!.Value).Result;

            if (controlePessoaExterna.Expiracao > DateTime.Now)
            {

                //adiciona primeiro a pessoa para obter o id do banco
                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                pessoa.ControlePessoaExternaId = null;
                pessoa = await _pessoaRepositorio.AdicionarAsyncSaveChanges(pessoa);

                await _controlePessoaExternaRepositorio.ExcluirAsync(controlePessoaExterna);


                return pessoa;
            }
            else
            {
                throw new ExcecaoDeDominio(new List<string> { "Token inválido para cadastro" });                
            }            
        }

        public async Task<Pessoa> Editar(PessoaModel pessoaModel)
        {
            try
            {
                var enderecoModel = pessoaModel.Endereco;
                pessoaModel.Endereco = null;

                var pessoa = _mapper.Map<Pessoa>(pessoaModel);
                await _pessoaRepositorio.EditarAsync(pessoa);                              

                if (enderecoModel != null)
                {
                    var endereco = _mapper.Map<Endereco>(enderecoModel);
                    if (endereco.Id == 0)
                        endereco = await _repositorioEndereco.AdicionarAsyncSaveChanges(endereco);
                    else
                        endereco = await _repositorioEndereco.EditarAsync(endereco);

                    pessoa.Endereco = endereco;
                    pessoa = await _pessoaRepositorio.EditarAsync(pessoa);
                }

                return pessoa;

            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var pessoa = await _repositorio.ObterPorIdAsync(id);
                await _repositorio.ExcluirAsync(pessoa);

                return "Excluído com sucesso";
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<string> DesassociarPessoaProcesso(int idPessoa, int idProcesso)
        {
            var empresaId = _user.EmpresaCurrent.Id;
            var result = _repositorioPessoaProcesso.ObterListaFiltroAsync(o => o.PessoaId == idPessoa && o.ProcessoId == idProcesso).Result.FirstOrDefault();
            await _repositorioPessoaProcesso.ExcluirAsync(result!);
            return "excluido com sucesso";
        }
    }
}
