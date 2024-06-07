using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.database;

namespace ProjetoP2.Models
{

    public class Chamado
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public Usuario Usuario { get; set; }

        [MaxLength(64)]
        public string Assunto { get; set; }

        public DateTime Data {  get; set; }

        public List<Mensagem> Mensagens { get; set; }

        private Chamado() { }

        public Chamado(string assunto, Usuario usuario)
        {
            this.Assunto = assunto;
            this.Usuario = usuario;
            this.Data = DateTime.Now;
        }
    }
}
