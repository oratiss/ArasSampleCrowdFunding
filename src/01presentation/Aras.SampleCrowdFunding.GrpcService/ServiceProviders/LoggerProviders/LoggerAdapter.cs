namespace Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders;


public class LoggerAdapter : ILogger
{
    private readonly Serilog.ILogger _logger;

    public LoggerAdapter(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        _logger.Write((Serilog.Events.LogEventLevel)logLevel, exception, formatter(state, exception));
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true; // Adjust as needed
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null; // No scope support in this example
    }
}

