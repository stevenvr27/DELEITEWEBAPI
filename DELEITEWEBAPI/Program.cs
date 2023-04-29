using DELEITEWEBAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Agregar la información de conexión contra base de datos. 
            //tenemos varias formas para lograr esto. 

            //1*. Agregar la info al archivo appsettings.json. 
            //2. Utilizar User Secrets (funciona localmente y por cuenta). 
            //3. Programar técnica personalizada de encriptación de la cadena

            //obtenermos información de la cadena de conexión almacenada en appsettigs.json 
            var CnnStrBuilder = new SqlConnectionStringBuilder(
                builder.Configuration.GetConnectionString("CNNSTR"));

            //definimos una variable local que almacene el cnn string 
            string cnnStr = CnnStrBuilder.ConnectionString;

            //definir la ccnstrin al proyecto antes de iniciarlo
            builder.Services.AddDbContext<DeleiteContext>(options => options.UseSqlServer(cnnStr));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
 