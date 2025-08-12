
namespace Sgmj.Modelos.Models
{
    public class Setor
    {
        public int Id { get; set; }
        public string NomeSetor { get; set; }
        public virtual ICollection<Congregacao> Congregacoes { get; set; } = new List<Congregacao>();
        
    }
}
