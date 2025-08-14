using AutoMapper;
using Sgmj.Modelos.Models;
using SGMJ.API.Dtos;
using SGMJ.API.Request;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.DAL;
using SGMJ.Dados.Repository;

namespace SGMJ.API.Services.Implementations
{
    public class JovemService : IJovemService
    {
        private readonly IMapper _iMaper;
        private readonly IJovemRepository _jovemRepository;
        private readonly DAL<Congregacao> _dalCongregacao;

        public JovemService(IJovemRepository jovemRepository, DAL<Congregacao> dalCongregacao, IMapper iMaper)
        {
            _jovemRepository = jovemRepository;
            _dalCongregacao = dalCongregacao;
            _iMaper = iMaper;
        }
        public Task Adcionar(JovemDto jovem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(JovemRequestEdit request)
        {
            throw new NotImplementedException();
        }

        public Task<JovemDto> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<JovemDto>> ListarJovens()
        {
            var listaJovens = await _jovemRepository.ListarAsync();     
            return _iMaper.Map<List<JovemDto>>(listaJovens);
        }
    }
}
