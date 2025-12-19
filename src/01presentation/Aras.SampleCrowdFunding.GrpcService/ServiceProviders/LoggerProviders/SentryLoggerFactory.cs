using Serilog;
using Serilog.Events;
using ILogger = Microsoft.Extensions.Logging.ILogger;


namespace Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders;

public class SentryLoggerFactory : ICustomLoggerFactory
{
    private readonly IConfiguration _configuration;

    public SentryLoggerFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ILogger CreateLogger(string loggerProvider, string categoryName)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Sentry(o =>
            {
                o.Dsn = _configuration["Sentry:DSN"];
                o.MinimumBreadcrumbLevel = LogEventLevel.Information;
                o.MinimumEventLevel = LogEventLevel.Error;
            })
            .CreateLogger();

        return new LoggerAdapter(logger);
    }

}