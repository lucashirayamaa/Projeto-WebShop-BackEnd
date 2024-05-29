using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.database;

namespace ProjetoP2.Models {

    public enum PerfilUsuarioEnum
    {
        Cliente,
        Administrador
    }

    public class Usuario 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
           
        public string Email { get; set; }

        public string Senha { get; set; }
        public PerfilUsuarioEnum Perfil {  get; set; }

        private Usuario() { }

        public Usuario(string email, string senha, PerfilUsuarioEnum perfil)
        {
            Email = email;
            Senha = senha;
            Perfil = perfil;
        }


    }
}
