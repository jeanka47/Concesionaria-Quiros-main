using ConcesionariaQuiros.Data;
using Microsoft.EntityFrameworkCore;

namespace ConcesionariaQuiros
{
    public class Program
       {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Servicios
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ConcesionariaContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Swagger en desarrollo
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Concesionaria API V1");
                    c.RoutePrefix = string.Empty; // 👈 Swagger abre en la raíz
                });
            }

            // ⚠️ Desactivamos HTTPS redirection porque en Mac no hay certificado configurado
            // app.UseHttpsRedirection();

            app.UseCors("ReactPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
