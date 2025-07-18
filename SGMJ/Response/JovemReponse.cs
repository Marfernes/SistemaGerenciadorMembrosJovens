using Sgmj.Modelos.Models;
namespace SGMJ.API.Response;
public record JovemReponse(int Id, string Nome, DateTime DataNascimento, string Telefone, string Email, int SetorId, Setor Setor, string ? FotoPerfil);


