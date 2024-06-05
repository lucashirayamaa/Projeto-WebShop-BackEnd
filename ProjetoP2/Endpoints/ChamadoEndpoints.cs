using Microsoft.EntityFrameworkCore;
using ProjetoP2.database;
using ProjetoP2.DTOs;
using ProjetoP2.Models;
using ProjetoP2.Service;
using ProjetoP2.Utils;
using System.Security.Claims;

namespace ProjetoP2.Endpoints
{
    public static class ChamadoEndpoints
    {
        public static void RegistrarEndpointsChamados(this IEndpointRouteBuilder rotas)
        {
            RouteGroupBuilder rotaChamados = rotas.MapGroup("/chamados");


            // Cria chamado
            rotaChamados.MapPost("/", (ProjetoP2DbContext dbContext, ClaimsPrincipal _usuarioLogado, ChamadoDTOInput chamadoInput) =>
            {

                // Verifica se o usuário está logado

                Usuario usuarioLogado = UserService.GetUsuarioPorUsuarioLogado(dbContext, _usuarioLogado);

                var novoChamado = dbContext.Chamados.Add(chamadoInput.ToChamado(usuarioLogado));
            
                Mensagem mensagem = new Mensagem(novoChamado.Entity, chamadoInput.Mensagem, usuarioLogado);

                var novaMensagem = dbContext.Mensagens.Add(mensagem);
                dbContext.SaveChanges();

                return TypedResults.Created($"/chamados/{novoChamado.Entity.Id}");
            });


            // Adiciona nova mensagem a chamado existente

            rotaChamados.MapPost("/{Id}/mensagem", (ProjetoP2DbContext dbContext, ClaimsPrincipal _usuarioLogado, int Id, MensagemDTOInput mensagemInput) =>
            {
                // Busca o chamado pelo ID
                var chamado = dbContext.Chamados.Find(Id);

                if (chamado == null)
                {
                    return Results.NotFound();
                }

                // Obtém o usuário logado
                Usuario usuarioLogado = UserService.GetUsuarioPorUsuarioLogado(dbContext, _usuarioLogado);

                if (usuarioLogado == null)
                {
                    return Results.NotFound();
                }

                // Cria uma nova mensagem
                var novaMensagem = new Mensagem(chamado, mensagemInput.Conteudo, usuarioLogado);
                dbContext.Mensagens.Add(novaMensagem);
                dbContext.SaveChanges();

                return TypedResults.Created($"/chamados/{Id}/mensagem");
            }).Produces<ChamadoDTOOutput>().RequireAuthorization();



            // Procura Chamado usando ID
            rotaChamados.MapGet("/{Id}", (ProjetoP2DbContext dbContext, int Id) =>
            {
                var chamado = dbContext.Chamados.Where(c => c.Id == Id).Select(c => new
                {
                  c.Id,
                  c.Assunto,
                  c.Data,
                  Usuario = new
                  {
                      c.Usuario.Id,
                      c.Usuario.Email
                  }
              }).FirstOrDefault();


                if (chamado == null)
                {
                    return Results.NotFound();
                }

                return TypedResults.Ok(chamado);
            }).Produces<object>().RequireAuthorization("admin");


            rotaChamados.MapGet("/{Id}/Mensagens", (ProjetoP2DbContext dbContext, int Id) =>
            {
            }).Produces<ChamadoDTOOutput>().RequireAuthorization("admin");



        }

      
    }
}
