using api.Settings;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;

namespace api.Functions
{
    public class GetSettings
    {
        private readonly ILogger _logger;
        private readonly AppSettings _appSettings;

        public GetSettings(ILoggerFactory loggerFactory, IOptions<AppSettings> settings)
        {
            _logger = loggerFactory.CreateLogger<GetSettings>();
            _appSettings = settings.Value;
        }

        [Function("settings")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req, ExecutionContext context)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            //response.Headers.Add("Content-Type", "text/plain; charset=utf-8");
            //response.WriteString("Welcome to Azure Functions!");

            var value = _appSettings;

            return response;
        }
    }
}
