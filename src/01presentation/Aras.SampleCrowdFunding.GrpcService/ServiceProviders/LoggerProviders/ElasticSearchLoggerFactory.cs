using System.Reflection;
using Elasticsearch.Net;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders
{
    public class ElasticSearchLoggerFactory : ICustomLoggerFactory
    {
        private readonly IConfiguration _configuration;

        public ElasticSearchLoggerFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ILogger CreateLogger(string loggerProvider, string categoryName)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Debug()
                .WriteTo.Console()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new SingleNodeConnectionPool(new Uri(_configuration["Elastic:Uri"]!)))
                {
                    IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name!.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}",
                    MinimumLogEventLevel = LogEventLevel.Information,
                    AutoRegisterTemplate = true,
                    EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog
                })
                .Enrich.WithProperty("Environment", environment!)
                .ReadFrom.Configuration(_configuration)
                .CreateLogger();



            return new LoggerAdapter(logger);
        }
    }
}
