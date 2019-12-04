using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using WebAPI;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace WebAPIIntegrationTestProject
{
    class TestClientProvider
    {
        public HttpClient Client { get; private set; }

        private readonly TestServer _server;
        //private readonly HttpClient _client;

        public TestClientProvider()
        {
            var projectDir = System.IO.Directory.GetCurrentDirectory();
            _server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
            .UseContentRoot(projectDir)
            .UseConfiguration(new ConfigurationBuilder()
                .SetBasePath(projectDir)
                .AddJsonFile("appsettings.json")
                .Build()
            )
           .UseStartup<Startup>());

            Client = _server.CreateClient();

            Client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
