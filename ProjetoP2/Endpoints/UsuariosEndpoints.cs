using ProjetoP2.database;
using ProjetoP2.Models;
using ProjetoP2.Utils;

namespace ProjetoP2.Endpoints
{
    public static class UsuariosEndpoints
    {
        public static void RegistrarEndpointsUsuarios(this IEndpointRouteBuilder rotas)
        {
            
            RouteGroupBuilder rotaUsuarios = rotas.MapGroup("/usuarios").RequireAuthorization("admin");


            //GET USUARIOS//
            rotaUsuarios.MapGet("/", (ProjetoP2DbContext dbContext) =>
            {

                IEnumerable<Usuario> usuariosFiltrados = dbContext.Usuarios;


            });
            
            
            
            
        }

    }
}
