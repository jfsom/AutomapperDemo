using AutomapperDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace AutomapperDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                // Optionally, configure JSON options or other formatter settings
                .AddJsonOptions(options =>
                {
                    // Configure JSON serializer settings to keep the Original names in serialization and deserialization
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

            // Register the ProductDbContext with dependency injection
            builder.Services.AddDbContext<ProductDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDBConnection")));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

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