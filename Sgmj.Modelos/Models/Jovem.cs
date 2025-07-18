
namespace Sgmj.Modelos.Models
{
    public class Jovem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Chave estrangeira para o Setor
        public int SetorId { get; set; }

        // Propriedade de navegação: um Jovem pertence a um Setor
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Setor Setor { get; set; }
        public string FotoPerfil { get; set; } = string.Empty;

        public Jovem(string nome, DateTime dataNascimento, string telefone, string email, int setorId)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Email = email;
            SetorId = setorId;
        }

    }
}
