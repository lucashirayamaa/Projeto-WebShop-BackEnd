using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using ProjetoP2.database;
using ProjetoP2.Models;

namespace ProjetoP2.Endpoints 
{ 
    public static class Clientes 
    { 
        public static void RegistrarEndPointsClientes(this IEndpointRouteBuilder rotas) 
        {
            RouteGroupBuilder rotaClientes = rotas.MapGroup("/clientes");
            

            rotaClientes.MapPost("/", (ProjetoP2DbContext dbContext, Cliente cliente) => 
            {
                try
                {
                    dbContext.clientes.Add(cliente);
                    dbContext.SaveChanges();

                    return TypedResults.Created();
                }
                catch (DbUpdateException ex)
                {
                    return Results.Problem("Nome de usuário já existe");
                }
                catch (Exception ex) 
                {
                    return Results.Problem();
                }
            });

            rotaClientes.MapPut("/{Id}", (ProjetoP2DbContext dbContext, int Id, Cliente cliente) =>
            {
                try
                {

                    Cliente? clienteExiste = dbContext.clientes.Find(Id);

                    cliente.Id = Id;

                    dbContext.Entry(clienteExiste).CurrentValues.SetValues(cliente);
                    dbContext.SaveChanges();

                    return TypedResults.NoContent();
                }
                catch (ArgumentNullException ex)
                {
                    return Results.Problem("Id não existente");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
                

            });

            rotaClientes.MapDelete("/{Id}", (ProjetoP2DbContext dbContext, int Id) =>
            {
                try
                {
                    Cliente? clienteExiste = dbContext.clientes.Find(Id);


                    dbContext.clientes.Remove(clienteExiste);
                    dbContext.SaveChanges();

                    return TypedResults.NoContent();
                }
                catch (ArgumentNullException ex)
                {
                    return Results.Problem("Id não existente");
                }
                catch (Exception ex)
                {
                    return Results.Problem();
                }
            });
        
        }
    }
}
