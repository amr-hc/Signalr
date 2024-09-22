using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace SignalR
{
    public class Startup
    {
        // Configure services method to register SignalR services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR(); // Adds SignalR services to the project
        }

        // Configure method to map the SignalR hubs
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting(); // Enables routing

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chatHub"); // Map your SignalR hub here
            });

            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
