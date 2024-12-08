using System.Net;
using UniWebShop.Backend.Services;
using UniWebShop.DataAccess;
using UniWebShop.DataAccess.DataAccess;
using UniWebShop.DataAccess.Repositories;
using UniWebShop.DataAccess.Repositories.Core;

namespace UniWebShop.Backend
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string baseUrl = $"http://127.0.0.1:5232";
            builder.WebHost.UseUrls(baseUrl);

            const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            // Configure CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000");
                        policy.AllowAnyMethod();
                        policy.WithHeaders("content-type");
                    });
            });

            // Add services to the container.
            builder.Services.AddDbContext<UniWebShopDbContext>();
            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<UserService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<IUserQuestionRepository, UserQuestionRepository>();
            builder.Services.AddScoped<UserQuestionService>();

            // Add Swagger for API documentation
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Middleware
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors(MyAllowSpecificOrigins);

            // Map controllers
            app.MapControllers();

            // Run the application
            app.Run();
        }
    }
}
