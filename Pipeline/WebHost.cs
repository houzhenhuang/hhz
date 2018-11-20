﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pipeline.Interfaces;

namespace Pipeline
{
    public class WebHost : IWebHost
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _config;

        public WebHost(IServiceCollection services,IConfiguration config)
        {
            this._serviceProvider = services.BuildServiceProvider();
            this._config = config;
        }
        public void Start()
        {
            IApplicationBuilder applicationBuilder = _serviceProvider.GetRequiredService<IApplicationBuilder>();
            _serviceProvider.GetRequiredService<IStartup>().Configure(applicationBuilder);

            IServer server = _serviceProvider.GetRequiredService<IServer>();
            IServerAddressesFeature addressFeatures = server.Features.Get<IServerAddressesFeature>();

            string addresses = _config["ServerAddresses"] ?? "http://localhost:5000";
            foreach (string address in addresses.Split(';'))
            {
                addressFeatures.Addresses.Add(address);
            }

            server.Start(new HostingApplication(applicationBuilder.Build()));
        }
    }
}
