using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ProjetoP2.database;

namespace ProjetoP2.Models
{
    public class Mensagem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public Chamado Chamado { get; set; }
        public Usuario Remetente { get; set; }
        public Usuario Destinatario { get; set; }

        [MaxLength(255)]
        public string Conteudo { get; set; }

        public DateTime Data {  get; set; }

        private Mensagem() { }

        public Mensagem(Chamado chamado, Usuario remetente, Usuario destinatario)
        {
            this.Chamado = chamado;
            this.Remetente = remetente;
            this.Destinatario = destinatario;
            this.Data = DateTime.Now;
        }


    }
}
