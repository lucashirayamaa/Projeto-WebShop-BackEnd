using ProjetoP2.Models;
using Microsoft.OpenApi.Extensions;

namespace ProjetoP2.DTOs
{
    public class UsuarioDtoInput
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Celular { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public PerfilUsuarioEnum Perfil { get; set; }

        public Usuario ToUsuario()
        {

            return new Usuario(Nome, Celular, Cpf, Email, Senha, Perfil);
        }
    }

    public class UsuarioDtoOutput
    {
        public int Id { get; set; }
    
        public string Email { get; set; }


        public PerfilUsuarioEnum Perfil { get; set; }

        public UsuarioDtoOutput(int id, string email, PerfilUsuarioEnum perfil)
        {
            this.Id = id;
            this.Email = email;
            this.Perfil = perfil;
        }
    }



}