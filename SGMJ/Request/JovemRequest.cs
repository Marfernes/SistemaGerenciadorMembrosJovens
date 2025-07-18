using Sgmj.Modelos.Models;
using System.ComponentModel.DataAnnotations;
namespace SGMJ.API.Request;
public record JovemRequest([Required]string nome, DateTime dataNascimento, string telefone,[Required] string email, int setorId, string ? fotoPerfil);


