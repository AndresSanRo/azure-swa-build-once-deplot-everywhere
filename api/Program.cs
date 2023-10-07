using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config.AddEnvironmentVariables();
        var settings = config.Build();
        var appConfConnStr = settings.GetValue<string>("AppConfigConnectionString");

        config.AddAzureAppConfiguration(options =>
        {
            options.Connect(appConfConnStr);
        });        
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();