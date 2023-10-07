using api.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var host = new HostBuilder()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddEnvironmentVariables();
        var settings = config.Build();
        var appConfConnStr = settings.GetValue<string>("AppConfigConnectionString");
        var environment = hostingContext.HostingEnvironment.EnvironmentName;

        config.AddAzureAppConfiguration(options =>
        {
            options.Connect(appConfConnStr).Select(KeyFilter.Any, environment);
        });        
    })
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((host, services) =>
    {
        services.Configure<AppSettings>(host.Configuration.GetSection("Settings"));

    })
    .Build();

host.Run();