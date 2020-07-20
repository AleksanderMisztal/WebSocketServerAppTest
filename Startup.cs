using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.WebSockets;
using GameServer.Networking;
using System.Linq;

namespace GameServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseWebSockets();

            app.Use(async (context, next) =>
            {
                if (context.WebSockets.IsWebSocketRequest)
                {
                    WebSocket socket = await context.WebSockets.AcceptWebSocketAsync();

                    await Server.ConnectNewClient(socket);
                }
                else
                {
                    await next();
                }
            });

            app.Run(async context =>
            {
                string[] css = GameHandler.clientToUsername.Select(item => $"({item.Key} : {item.Value})").ToArray();
                string cs = string.Join("\n", css);

                string[] gss = GameHandler.games.Select(item => $"{item.Key} : {item.Value}").ToArray();
                string gs = string.Join("\n", gss);

                await context.Response.WriteAsync(cs + "\n" + gs);
            });
        }
    }
}
