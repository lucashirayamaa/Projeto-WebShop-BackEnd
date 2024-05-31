using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.database;

namespace ProjetoP2.Models {
    public class Usuario 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string NomeUsuario { get; set; }
           
        public string Email { get; set; }

        public string Senha { get; set; }

        private Usuario() { }

        public Usuario(string nomeUsuario, string email, string Senha) 
        { 
            this.NomeUsuario = nomeUsuario;
            this.Email = email;
            this.Senha = Senha;
        }

    }
}
