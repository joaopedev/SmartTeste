using Microsoft.EntityFrameworkCore;
using SmartTeste.Data;
using SmartTeste.Repositorio;
using SmartTeste.Repositorio.Interface;

namespace SmartTeste
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<SistemaCadastroDBcontext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DataBase")));
            //"Host=localhost;Database=my_db;Username=my_user;Password=my_pw"
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}