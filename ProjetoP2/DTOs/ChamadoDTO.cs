using ProjetoP2.Models;

namespace ProjetoP2.DTOs
{
    public class ChamadoDTOInput
    {
        public string Assunto {  get; set; }
        public string Mensagem { get; set; }

        public ChamadoDTOInput(string assunto, string mensagem)
        {
            Assunto = assunto;
            Mensagem = mensagem;
        }

        public Chamado ToChamado(Usuario usuario)
        {

            return new Chamado(Assunto, usuario);
        }

    }

    public class ChamadoDTOOutput
    {
        public int Id { get; set; }
        public string Assunto { get; set; }
        public string Mensagem { get; set; }

        public Usuario usuario { get; set; }

        public DateTime Data { get; set; }

        public ChamadoDTOOutput(int id, string assunto, string mensagem, Usuario usuario, DateTime data)
        {
            Id = id;
            Assunto = assunto;
            Mensagem = mensagem;
            this.usuario = usuario;
            Data = data;
        }
    }



}
