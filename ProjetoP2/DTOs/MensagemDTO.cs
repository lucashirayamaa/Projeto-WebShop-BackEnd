namespace ProjetoP2.DTOs
{
    public class MensagemDTOInput
    {
        public string EmailRemetente { get; set; }
        public string Conteudo { get; set; }

        public MensagemDTOInput(string emailRemetente, string conteudo)
        {
            EmailRemetente = emailRemetente;
            Conteudo = conteudo;
        }
    }
}
