using System;
using System.Net.Http;
using JB.Integration.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace JB.Integration.Api.Test.Factories
{
    public class IntegrationWebApplicationFactory<IStartup> : WebApplicationFactory<IStartup> where IStartup : class
    {
        public HttpClient Client { get; private set; }

        public IntegrationWebApplicationFactory()
        {
            PrepareClient();
        }

        private void PrepareClient()
        {
            var options = new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false,
                BaseAddress = new Uri("http://localhost:28777/"),
                HandleCookies = false,
                MaxAutomaticRedirections = 6
            };

            Client = CreateClient(options);
        }

        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseEnvironment("IntegrationTests")
                        .UseUrls("http://*:28777")
                        .UseStartup(typeof(IStartup));
                });
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            
            base.ConfigureWebHost(builder);
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            return base.CreateHost(builder)
                .MigrateDatabase();
        }

        protected override void ConfigureClient(HttpClient client)
        {
            base.ConfigureClient(client);
        }

        public T GetService<T>()
        {
            if (Server == null)
                throw new ArgumentNullException("Cannot get services before the server is created");

            return (T)this.Services.GetService(typeof(T));
        }

        public DbContext GetDbContext()
        {
            return GetService<IntegrationDbContext>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
