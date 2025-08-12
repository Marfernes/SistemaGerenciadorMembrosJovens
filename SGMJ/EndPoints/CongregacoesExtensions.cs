using Microsoft.AspNetCore.Mvc;
using Sgmj.Modelos.Models;
using SGMJ.API.Services.Interfaces;
using SGMJ.Dados.Banco.DAL;

namespace SGMJ.API.EndPoints
{
    public static class CongregacoesExtensions
    {
        public static void AddEndPointsCongregacoes(this WebApplication app)
        {
            app.MapGet("/Congregacoes", async ([FromServices] ICongregacaoService _iCongregacaoservice) =>
            {
                var congregacoes = await _iCongregacaoservice.ListarCongregacoes();
                if (congregacoes is null)
                    return Results.NotFound();

                return Results.Ok(congregacoes);
            });
        }
    }
}
