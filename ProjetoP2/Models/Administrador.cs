using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.database;

namespace ProjetoP2.Models
{
    public class Administrador
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        public string Email { get; set; }

        public string Senha { get; set; }

        private Administrador() { }

        public Administrador(string email, string Senha)
        {
            this.Email = email;
            this.Senha = Senha;
        }

    }
}
