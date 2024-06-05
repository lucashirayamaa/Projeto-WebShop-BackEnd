using Microsoft.EntityFrameworkCore;
using ProjetoP2.database;
using ProjetoP2.DTOs;
using ProjetoP2.Models;
using ProjetoP2.Utils;

namespace ProjetoP2.Endpoints

{
   
    public static class MensagemEndpoints
    {
        public static void RegistrarEndpointsMensagens(this IEndpointRouteBuilder rotas)
        {
            RouteGroupBuilder rotaMensagens = rotas.MapGroup("/mensagens");


            // Cria Mensagem
            rotaMensagens.MapPost("/", (ProjetoP2DbContext dbContext, Mensagem mensagem) =>
            {
                var novaMensagem = dbContext.Mensagens.Add(mensagem);
                dbContext.SaveChanges();

                return TypedResults.Created($"/mensagens/{mensagem.Id}");
            });


        }
    }
}