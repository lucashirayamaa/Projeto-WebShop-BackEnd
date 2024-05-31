using ProjetoP2.Models;
using Microsoft.OpenApi.Extensions;

namespace ProjetoP2.DTOs
{
    public class UsuarioDtoInput
    {
        public string Email { get; set; }

        public string Senha { get; set; }

        public string Perfil { get; set; }

        public Usuario ToUsuario()
        {
            PerfilUsuarioEnum perfil;
            Enum.TryParse(Perfil, out perfil);
            return new Usuario(Email, Senha, perfil);
        }
    }

    public class UsuarioDtoOutput
    {
        public int Id { get; set; }
    
        public string Email { get; set; }


        public string Perfil { get; set; }

        public UsuarioDtoOutput(int id, string email, PerfilUsuarioEnum perfil)
        {
            this.Id = id;
            this.Email = email;
            this.Perfil = perfil.ToString();
        }
    }




}