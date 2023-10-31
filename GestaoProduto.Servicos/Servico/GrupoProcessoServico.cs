using AutoMapper;
using GestaoProduto.Dominio._Base;
using GestaoProduto.Dominio.Entity._Processo;
using GestaoProduto.Dominio.Entity._GrupoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._GrupoProcesso;
using GestaoProduto.Compartilhado.Interfaces.Repositorio._Processo;
using GestaoProduto.Dominio;
using GestaoProduto.Dados.Repositorio._GrupoProcesso;
using System.Linq;
using Newtonsoft.Json;
using GestaoProduto.Compartilhado.Interfaces.Servico._GrupoProcesso;
using GestaoProduto.Compartilhado.Model._GrupoProcesso;
using GestaoProduto.Compartilhado.Model._GrupoProcessoDto;

namespace GestaoProduto.Servico._GrupoProcesso
{
    public class GrupoProcessoServico : IGrupoProcessoServico
    {
        private readonly IRepositorio<GrupoProcesso> _repositorioGrupoProcesso;
        private readonly IRepositorio<Processo> _repositorioProcesso;
        private readonly IGrupoProcessoRepositorio _grupoProcessoRepositorio;
        private readonly IProcessoRepositorio _processoRepositorio;
        private readonly IMapper _mapper;

        public GrupoProcessoServico(IRepositorio<GrupoProcesso> repositorioGrupoProcesso,
                                        IRepositorio<Processo> repositorioProcesso,
                                        IGrupoProcessoRepositorio grupoProcessoRepositorio,
                                        IProcessoRepositorio processoRepositorio,
                                        IMapper mapper)
        {
            _repositorioGrupoProcesso = repositorioGrupoProcesso;
            _repositorioProcesso = repositorioProcesso;
            _grupoProcessoRepositorio = grupoProcessoRepositorio;
            _processoRepositorio = processoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<GrupoProcessoModel>> Listar()
        {
            var listaGrupos = await _processoRepositorio.ListarGrupoProcessoModel();
           
            return listaGrupos;
        }

        public async void CriaGrupoPadrao(string nome, string posicao, GrupoProcesso grupoProcesso) {
            var processo = new Processo();
            processo.Numero = nome;
            processo.Descricao = posicao;
            processo.GrupoProcesso = grupoProcesso;
            processo.Ativo = true;

            await _repositorioProcesso.AdicionarAsync(processo);
        }

        public async Task CriaGrupoInicial()
        {
            #region grupo 1
            var grupoProcesso = new GrupoProcesso();
            grupoProcesso.Nome = "Grupo 1";
            grupoProcesso.Posicao = 1;
            grupoProcesso.Ativo = true;

            await _repositorioGrupoProcesso.AdicionarAsync(grupoProcesso);

            CriaGrupoPadrao("111.111", "Processo 1", grupoProcesso);
            CriaGrupoPadrao("222.222", "Processo 2", grupoProcesso);
            CriaGrupoPadrao("333.333", "Processo 3", grupoProcesso);           
            
            #endregion

            #region grupo 1
            grupoProcesso = new GrupoProcesso();
            grupoProcesso.Nome = "Grupo 2";
            grupoProcesso.Posicao = 1;
            grupoProcesso.Ativo = true;

            await _repositorioGrupoProcesso.AdicionarAsync(grupoProcesso);

            CriaGrupoPadrao("111.111", "Processo 1", grupoProcesso);
            CriaGrupoPadrao("222.222", "Processo 2", grupoProcesso);
            CriaGrupoPadrao("333.333", "Processo 3", grupoProcesso);
            #endregion
        }

        public async Task<GrupoProcesso> Adicionar(GrupoProcessoDto grupoProcessoDto)
        {
            try
            {
                var grupoProcesso = _mapper.Map<GrupoProcesso>(grupoProcessoDto);
                await _repositorioGrupoProcesso.AdicionarAsync(grupoProcesso);

                CriaGrupoPadrao("111.111", "Processo 1", grupoProcesso);

                return grupoProcesso;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }

        public async Task<GrupoProcesso> Editar(GrupoProcessoDto grupoProcessoDto)
        {
            try
            {
                var grupoProcesso = _mapper.Map<GrupoProcesso>(grupoProcessoDto);
                await _repositorioGrupoProcesso.EditarAsync(grupoProcesso);

                return grupoProcesso;
            }
            catch (ExcecaoDeDominio ex)
            {
                throw new Exception(ex.MensagensDeErro.First());
            }
        }
    }
}

