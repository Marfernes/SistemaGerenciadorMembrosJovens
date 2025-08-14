using Sgmj.Modelos.Models;
using SGMJ.API.Dtos;
using SGMJ.API.Request;

namespace SGMJ.API.Services.Interfaces
{
    public interface ICongregacaoService
    {
        
        Task<List<CongregacaoDto>> ListarCongregacoes();
        Task<CongregacaoDto> BuscarPorId(int id);
        Task Adcionar(CongregacaoDto congregacao);
        Task<bool> Deletar(int id);
        Task<bool> Atualizar(CongregacaoRequestEdit request);
    }
}
