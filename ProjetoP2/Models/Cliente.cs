using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.database;

namespace ProjetoP2.Models {
    public class Cliente 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public string NomeCliente { get; set; }
           
        public string Email { get; set; }

        public string Senha { get; set; }

        private Cliente() { }

        public Cliente(string nomeCliente, string email, string Senha) 
        { 
            this.NomeCliente = nomeCliente;
            this.Email = email;
            this.Senha = Senha;
        }

    }
}
