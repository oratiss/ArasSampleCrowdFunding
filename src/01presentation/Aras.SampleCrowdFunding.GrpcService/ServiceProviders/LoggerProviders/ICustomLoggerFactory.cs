namespace Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders;

public interface ICustomLoggerFactory
{
    ILogger CreateLogger(string loggerProvider, string categoryName);
}