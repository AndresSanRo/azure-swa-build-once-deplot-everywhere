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

        public GetSettings(ILoggerFactory loggerFactory, IOptionsSnapshot<AppSettings> settings)
        {
            _logger = loggerFactory.CreateLogger<GetSettings>();
            _appSettings = settings.Value;
        }

        [Function("settings")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req, ExecutionContext context)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(_appSettings);
            return response;
        }
    }
}
