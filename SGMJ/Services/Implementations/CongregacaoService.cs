using AutoMapper;
using Sgmj.Modelos.Models;
using SGMJ.API.Dtos;
using SGMJ.API.Request;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.DAL;

namespace SGMJ.API.Services.Implementations
{
    public class CongregacaoService : ICongregacaoService
    {
        private readonly DAL<Congregacao> _dalCongregacao;
        private readonly IMapper _iMaper;

        public CongregacaoService(DAL<Congregacao> dalCongregacao, IMapper iMaper)
        {
            _dalCongregacao = dalCongregacao;
            _iMaper = iMaper;
        }
        public Task Adcionar(CongregacaoDto congregacao)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(CongregacaoRequestEdit request)
        {
            throw new NotImplementedException();
        }

        public Task<CongregacaoDto> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CongregacaoDto>> ListarCongregacoes()
        {
            var listaCongregacaoes = await _dalCongregacao.ListarAsync();
            return _iMaper.Map<List<CongregacaoDto>>(listaCongregacaoes);
        }
    }
}
