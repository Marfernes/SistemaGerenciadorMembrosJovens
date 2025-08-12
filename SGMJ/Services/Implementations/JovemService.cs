using Sgmj.Modelos.Models;
using SGMJ.API.Request;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.DAL;

namespace SGMJ.API.Services.Implementations
{
    public class JovemService : IJovemService
    {
        private readonly DAL<Jovem> _dalJovem;
        public JovemService(DAL<Jovem> dalJovem)
        {
            _dalJovem = dalJovem;
        }
        public Task Adcionar(Jovem jovem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Atualizar(JovemRequestEdit request)
        {
            throw new NotImplementedException();
        }

        public Task<Jovem> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Jovem>> ListarJovens()
        {
            var listaJovens = await _dalJovem.ListarAsync();
            return listaJovens.ToList();
        }
    }
}
