using ProjetoP2.database;
using ProjetoP2.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ProjetoP2.Service
{
    public static class UserService
    {
        public static Usuario? GetUsuarioPorUsuarioLogado(ProjetoP2DbContext dbContext, ClaimsPrincipal usuarioLogado)
        {
            var usuarioLogadoId = usuarioLogado.Claims.FirstOrDefault(c => c.Type == "id");
            if (usuarioLogadoId is null)
            {
                return null;
            }

            Usuario? usuarioEncontrado = dbContext.Usuarios.FirstOrDefault(u => u.Id.ToString() == usuarioLogadoId.Value.ToString());
            return usuarioEncontrado;
        }
    }
}