using ProjetoP2.database;
using ProjetoP2.Models;
using ProjetoP2.Utils;


namespace ProjetoP2.Endpoints
{
    public static class Autenticacao
    {
        class ParametrosLogin
        {
            public string Email { get; set; }
            public string Senha { get; set; }
        }

        public static void RegistrarEndpointsAutenticacao(this IEndpointRouteBuilder rotas)
        {
            RouteGroupBuilder rotasAuth = rotas.MapGroup("/auth");

            rotasAuth.MapPost("/login", (ProjetoP2DbContext dbContext, ITokenService tokenService, ParametrosLogin usuario) =>
            {
                Usuario? usuarioEncontrado = dbContext.Usuarios.FirstOrDefault(u => u.Email == usuario.Email && u.Senha == usuario.Senha);

                if (usuarioEncontrado == null)
                {
                    return Results.NotFound();
                }

                string token = tokenService.CreateToken(usuarioEncontrado);

                return Results.Ok(new { token });

            });


        }
    }
}
