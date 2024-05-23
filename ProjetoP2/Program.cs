using ProjetoP2.database;
using ProjetoP2.Endpoints;

namespace ProjetoP2 {
    public class Program {
        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ProjetoP2DbContext>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.RegistrarEndPointsClientes();
            app.RegistrarEndPointsAdministradores();

            app.Run();
        }
    }
}
