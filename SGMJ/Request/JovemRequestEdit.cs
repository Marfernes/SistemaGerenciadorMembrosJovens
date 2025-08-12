using Sgmj.Modelos.Models;

namespace SGMJ.API.Request;
    public record JovemRequestEdit(int Id, string nome, DateTime dataNascimento, string telefone, string email, int setorId, Setor setor, string? fotoPerfil, Congregacao congregacao)
    : JovemRequest(nome, dataNascimento, telefone, email, setorId, fotoPerfil, congregacao);
