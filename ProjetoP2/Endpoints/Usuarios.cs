using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.database;
using ProjetoP2.Models;

namespace ProjetoP2.Endpoints 
{ 
    public static class Usuarios 
    { 
        public static void RegistrarEndPointsUsuarios(this IEndpointRouteBuilder rotas) 
        {
            RouteGroupBuilder rotaUsuarios = rotas.MapGroup("/usuarios");
            

            rotaUsuarios.MapPost("/", (ProjetoP2DbContext dbContext, Usuario usuario) => 
            {
                try
                {
                    dbContext.usuarios.Add(usuario);
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

            rotaUsuarios.MapPut("/{Id}", (ProjetoP2DbContext dbContext, int Id, Usuario usuario) =>
            {

                    Usuario? usuarioExiste = dbContext.usuarios.Find(Id);
                    if (usuarioExiste is null)
                    {
                        return Results.NotFound("Usuário não encontrado");
                    }
            
                    usuario.Id = Id;

                    dbContext.Entry(usuarioExiste).CurrentValues.SetValues(usuario);
                    dbContext.SaveChanges();

                    return TypedResults.NoContent();

            });

            rotaUsuarios.MapDelete("/{Id}", (ProjetoP2DbContext dbContext, int Id) =>
            {
                Usuario? usuarioExiste = dbContext.usuarios.Find(Id);
                if (usuarioExiste is null)
                {
                    return Results.NotFound("Usuário não encontrado");
                }

                dbContext.usuarios.Remove(usuarioExiste);
                dbContext.SaveChanges();

                return TypedResults.NoContent();
            });
        
        }
    }
}
