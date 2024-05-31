using ProjetoP2.database;
using ProjetoP2.Endpoints;
using ProjetoP2.Utils;
using ProjetoP2.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProjetoP2 {
    public class Program {
        public static void Main(string[] args) 
        {

            
            // Cria WebAplication
            var builder = WebApplication.CreateBuilder(args);

            // Config Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Config Cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermitirTodasOrigens",
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            // Config autenticação e autorização
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                     options.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = false,
                         ValidateAudience = false,
                         ValidateLifetime = false,
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SECRET_KEY"]!))
                     };
                 });

            
            // Config add autorização "Admin"
            builder.Services.AddAuthorizationBuilder()
                .AddPolicy("admin",
                    policy => policy.RequireRole(PerfilUsuarioEnum.Administrador.ToString())
               );

            // Config database
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ProjetoP2DbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            );

            
            
            builder.Services.AddDbContext<ProjetoP2DbContext>();

            // Registra Token Service
            builder.Services.AddSingleton<ITokenService, TokenService>();


            // Construção WebAplication
            var app = builder.Build();

            if (app.Environment.IsDevelopment()) 
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseCors("PermitirTodasOrigens");
            app.RegistrarEndpointsAutenticacao();
            app.RegistrarEndpointsUsuarios();
            app.RegistrarEndpointsChamados();
            app.Run();
        }
    }
}
