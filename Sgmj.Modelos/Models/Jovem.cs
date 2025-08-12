
namespace Sgmj.Modelos.Models
{
    public class Jovem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public int CongregacaoId { get; set; }
        public virtual Congregacao Congregacao { get; set; }
        public string FotoPerfil { get; set; } = string.Empty;

        public Jovem(string nome, DateTime dataNascimento, string telefone, string email, int congregacaoId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            CongregacaoId = congregacaoId;          
        }

    }
}
