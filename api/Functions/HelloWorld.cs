using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace api
{
    public class HelloWorld
    {
        private readonly ILogger _logger;

        public HelloWorld(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HelloWorld>();
        }

        [Function(nameof(HelloWorld))]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Hello world!");

            return response;
        }
    }
}
