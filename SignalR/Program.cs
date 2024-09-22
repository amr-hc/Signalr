using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SignalR
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add CORS services to allow cross-origin requests
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5500")
                           .AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials(); // Required for SignalR
                });
            });

            // Add SignalR services
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Use CORS middleware
            app.UseCors();

            // Map your SignalR hub
            app.MapHub<ChatHub>("/chatHub");

            app.Run();
        }
    }
}
