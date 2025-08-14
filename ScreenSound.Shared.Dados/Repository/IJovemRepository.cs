using Sgmj.Modelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGMJ.Dados.Repository
{
    public interface IJovemRepository
    {
        // Métodos CRUD básicos podem vir da DAL genérica
        Task<IList<Jovem>> ListarAsync();
        Task<Jovem?> BuscarPorIdAsync(int id);
        Task AdicionarAsync(Jovem jovem);
        Task AtualizarAsync(Jovem jovem);
        Task DeletarAsync(Jovem jovem);
    }
}
