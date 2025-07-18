using Microsoft.AspNetCore.Mvc;
using Sgmj.Modelos.Models;
using SGMJ.API.Response;
using SGMJ.Dados.Banco.DAL;
using SGMJ.API.Request;

namespace SGMJ.API.EndPoints
{
    public static class JovensExtensions
    {

        public static void AddEndPointsJovens(this WebApplication app)
        {

            #region Endpoint Jovens
            app.MapGet("/Jovens", ([FromServices] DAL<Jovem> dal) =>
            {
                var listaDeJovens = dal.Listar();
                if (listaDeJovens is null)
                {
                    return Results.NotFound();
                }
                var listaDeJovensResponse = EntityListToResponseList(listaDeJovens);
                return Results.Ok(listaDeJovensResponse);
            });

            app.MapGet("/Jovens/{nome}", ([FromServices] DAL<Jovem> dal, string nome) =>
            {
                var jovem = dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
                if (jovem is null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(EntityToResponse(jovem));

            });

            app.MapPost("/Jovens", async ([FromServices] IHostEnvironment env, [FromServices] DAL<Jovem> dal, [FromBody] JovemRequest jovemRequest) =>
            {

                var nome = jovemRequest.nome.Trim();
                var imagemJovem = DateTime.Now.ToString("ddMMyyyyhhss") + "." + nome + ".jpg";

                var path = Path.Combine(env.ContentRootPath, "wwwroot", "FotosPerfil", imagemJovem);
                if (!string.IsNullOrEmpty(jovemRequest.fotoPerfil))
                {
                    using MemoryStream ms = new MemoryStream(Convert.FromBase64String(jovemRequest.fotoPerfil!));
                    using FileStream fs = new(path, FileMode.Create);
                    await ms.CopyToAsync(fs);
                }



                var jovem = new Jovem(
                     nome,
                     jovemRequest.dataNascimento,
                     jovemRequest.telefone,
                     jovemRequest.email,
                     jovemRequest.setorId
                )
                {
                    FotoPerfil = $"/FotosPerfil/{imagemJovem}"
                };

                dal.Adicionar(jovem);
                return Results.Ok();
            });

            app.MapDelete("/Jovens/{id}", ([FromServices] DAL<Jovem> dal, int id) =>
            {
                var jovem = dal.RecuperarPor(a => a.Id == id);
                if (jovem is null)
                {
                    return Results.NotFound();
                }
                dal.Deletar(jovem);
                return Results.NoContent();

            });

            app.MapPut("/Jovens", ([FromServices] DAL<Jovem> dal, [FromBody] JovemRequestEdit jovemRequestEdit) =>
            {
                var jovemAtualizar = dal.RecuperarPor(a => a.Id == jovemRequestEdit.Id);
                if (jovemAtualizar is null)
                {
                    return Results.NotFound();
                }
                jovemAtualizar.Nome = jovemRequestEdit.nome;
                dal.Atualizar(jovemAtualizar);
                return Results.Ok();
            });
            #endregion
        }
        private static ICollection<JovemReponse> EntityListToResponseList(IEnumerable<Jovem> listaDeJovens)
        {
            return listaDeJovens.Select(a => EntityToResponse(a)).ToList();
        }

        private static JovemReponse EntityToResponse(Jovem jovem)
        {
            return new JovemReponse(jovem.Id, jovem.Nome, jovem.DataNascimento, jovem.Telefone, jovem.Email, jovem.SetorId, jovem.Setor, jovem.FotoPerfil);
        }
    }
}
