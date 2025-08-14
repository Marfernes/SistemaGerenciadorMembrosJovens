using SGMJ.API.Dtos;
using SGMJ.API.Request;

namespace SGMJ.API.Services.Interfaces
{
    public interface IJovemService
    {
        Task<List<JovemDto>> ListarJovens();
        Task<JovemDto> BuscarPorId(int  id);
        Task Adcionar (JovemDto jovem);
        Task<bool> Deletar(int id);
        Task<bool> Atualizar(JovemRequestEdit request);
    }
}
