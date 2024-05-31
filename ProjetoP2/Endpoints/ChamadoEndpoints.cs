using Microsoft.EntityFrameworkCore;
using ProjetoP2.database;
using ProjetoP2.DTOs;
using ProjetoP2.Models;
using ProjetoP2.Utils;

namespace ProjetoP2.Endpoints
{
    public static class ChamadoEndpoints
    {
        public static void RegistrarEndpointsChamados(this IEndpointRouteBuilder rotas)
        {
            RouteGroupBuilder rotaChamados = rotas.MapGroup("/chamados");


            // Cria chamado
            rotaChamados.MapPost("/", (ProjetoP2DbContext dbContext, Chamado chamado) =>
            {
                var novoChamado = dbContext.Chamados.Add(chamado);
                dbContext.SaveChanges();

                return TypedResults.Created($"/chamados/{chamado.Id}");
            });


            // Procura Chamado usando ID
            rotaChamados.MapGet("/", (ProjetoP2DbContext dbContext, int Id) =>
            {
                
                Chamado? chamado = dbContext.Chamados.Find(Id);

                if ( chamado == null )

                {
                    return Results.NotFound();
                }

                return TypedResults.Ok(chamado);
            }).Produces<Chamado>().RequireAuthorization("admin");

                
                
        }

      
    }
}
