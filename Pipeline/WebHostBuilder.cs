using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pipeline.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline
{
    public class WebHostBuilder : IWebHostBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _config;

        public WebHostBuilder()
        {
            this._services = new ServiceCollection().AddSingleton<IApplicationBuilder, ApplicationBuilder>();
            this._config = new ConfigurationBuilder().AddInMemoryCollection().Build();
        }
        public IWebHost Build() => new WebHost(_services, _config);

        public IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices)
        {
            configureServices(_services);
            return this;
        }

        public IWebHostBuilder UseSetting(string key, string value)
        {
            _config[key] = value;
            return this;
        }
    }
}
