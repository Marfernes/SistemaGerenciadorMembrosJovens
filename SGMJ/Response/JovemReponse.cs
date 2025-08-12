using Sgmj.Modelos.Models;
namespace SGMJ.API.Response;
public record JovemReponse(int Id, string Nome, DateTime DataNascimento, string Telefone, string Email, Setor Setor, string ? FotoPerfil, string Congregacao);


