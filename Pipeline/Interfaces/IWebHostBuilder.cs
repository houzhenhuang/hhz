using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Interfaces
{
    public interface IWebHostBuilder
    {
        IWebHost Build();
        IWebHostBuilder ConfigureServices(Action<IServiceCollection> configureServices);
        IWebHostBuilder UseSetting(string key, string value);
    }
}
