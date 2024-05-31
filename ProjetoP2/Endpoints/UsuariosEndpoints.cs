using ProjetoP2.database;
using ProjetoP2.DTOs;
using ProjetoP2.Models;
using ProjetoP2.Utils;

namespace ProjetoP2.Endpoints
{
    public static class UsuariosEndpoints
    {
        public static void RegistrarEndpointsUsuarios(this IEndpointRouteBuilder rotas)
        {
            
            RouteGroupBuilder rotaUsuarios = rotas.MapGroup("/usuarios");


            //Lista todos os Usuários //GET//
            rotaUsuarios.MapGet("/", (ProjetoP2DbContext dbContext) =>
            {

                IEnumerable<Usuario> usuariosFiltrados = dbContext.Usuarios;

                // Retorna os usuarios filtrados
                return Results.Ok(usuariosFiltrados.Select(u => u.GetUsuarioDtoOutput()).ToList());
            }).Produces<List<UsuarioDtoOutput>>().RequireAuthorization("admin");


            //Cadastra um Usuário //POST//
            rotaUsuarios.MapPost("/", (ProjetoP2DbContext dbContext, UsuarioDtoInput usuario) =>
            {
                Usuario _novoUsuario = usuario.ToUsuario();
                var novoUsuario = dbContext.Usuarios.Add(_novoUsuario);
                dbContext.SaveChanges();


                return TypedResults.Created<UsuarioDtoOutput>($"/usuarios/{novoUsuario.Entity.Id}", novoUsuario.Entity.GetUsuarioDtoOutput());
            }).Produces<UsuarioDtoOutput>();



        }

    }
}
