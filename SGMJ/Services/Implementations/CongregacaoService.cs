using Sgmj.Modelos.Models;
using SGMJ.API.Request;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.DAL;

namespace SGMJ.API.Services.Implementations
{
    public class CongregacaoService : ICongregacaoService
    {
        private readonly DAL<Congregacao> _dalCongregacao;

        public CongregacaoService(DAL<Congregacao> dalCongregacao)
        {
            _dalCongregacao = dalCongregacao;
        }
        public Task Adcionar(Congregacao congregacao)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(CongregacaoRequestEdit request)
        {
            throw new NotImplementedException();
        }

        public Task<Congregacao> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Congregacao>> ListarCongregacoes()
        {
            var listaCongregacaoes = await _dalCongregacao.ListarAsync();
            return listaCongregacaoes.ToList();
        }
    }
}
