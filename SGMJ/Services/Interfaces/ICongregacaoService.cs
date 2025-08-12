using Sgmj.Modelos.Models;
using SGMJ.API.Request;

namespace SGMJ.API.Services.Interfaces
{
    public interface ICongregacaoService
    {
        
        Task<List<Congregacao>> ListarCongregacoes();
        Task<Congregacao> BuscarPorId(int id);
        Task Adcionar(Congregacao congregacao);
        Task<bool> Deletar(int id);
        Task<bool> Atualizar(CongregacaoRequestEdit request);
    }
}
