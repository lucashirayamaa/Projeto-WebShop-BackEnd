using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.database;
using ProjetoP2.Models;

namespace ProjetoP2.Endpoints
{
    public static class Administradores
    {
        public static void RegistrarEndPointsAdministradores(this IEndpointRouteBuilder rotas)
        {
            RouteGroupBuilder rotaAdministradores = rotas.MapGroup("/administradores");


            rotaAdministradores.MapPost("/", (ProjetoP2DbContext dbContext, Administrador administrador) =>
            {
                try
                {
                    dbContext.administradores.Add(administrador);
                    dbContext.SaveChanges();

                    return TypedResults.Created();
                }
                catch (DbUpdateException ex)
                {
                    return Results.Problem("Nome de usuário já existe");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });

            rotaAdministradores.MapPut("/{Id}", (ProjetoP2DbContext dbContext, int Id, Administrador administrador) =>
            {
                try
                {

                    Administrador? administradorExiste = dbContext.administradores.Find(Id);

                    administrador.Id = Id;

                    dbContext.Entry(administradorExiste).CurrentValues.SetValues(administrador);
                    dbContext.SaveChanges();

                    return TypedResults.NoContent();
                }
                catch (ArgumentNullException ex)
                {
                    return Results.Problem("Id não existente");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }


            });

            rotaAdministradores.MapDelete("/{Id}", (ProjetoP2DbContext dbContext, int Id) =>
            {
                try
                {
                    Administrador? administradorExiste = dbContext.administradores.Find(Id);


                    dbContext.administradores.Remove(administradorExiste);
                    dbContext.SaveChanges();

                    return TypedResults.NoContent();
                }
                catch (ArgumentNullException ex)
                {
                    return Results.Problem("Id não existente");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });

        }
    }
}
