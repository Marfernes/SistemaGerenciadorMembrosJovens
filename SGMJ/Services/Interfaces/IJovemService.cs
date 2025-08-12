using Sgmj.Modelos.Models;
using SGMJ.API.Request;
using System.Threading.Tasks;

namespace SGMJ.API.Services.Interfaces
{
    public interface IJovemService
    {
        Task<List<Jovem>> ListarJovens();
        Task<Jovem> BuscarPorId(int  id);
        Task Adcionar (Jovem jovem);
        Task<bool> Deletar(int id);
        Task<bool> Atualizar(JovemRequestEdit request);
    }
}
