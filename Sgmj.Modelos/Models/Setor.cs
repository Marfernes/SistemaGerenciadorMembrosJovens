
namespace Sgmj.Modelos.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string NomeSetor { get; set; }
        public string Congregacao { get; set; }
        public virtual ICollection<Jovem> Jovens { get; set; } = new List<Jovem>(); // Inicialize a coleção
    }
}
