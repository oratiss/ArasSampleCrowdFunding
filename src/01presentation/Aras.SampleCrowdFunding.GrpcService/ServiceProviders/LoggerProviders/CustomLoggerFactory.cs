namespace Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders
{
    public class CustomLoggerFactory : ICustomLoggerFactory
    {
        private readonly ElasticSearchLoggerFactory _elasticSearchFactory;
        private readonly SentryLoggerFactory _sentryFactory;

        public CustomLoggerFactory(ElasticSearchLoggerFactory elasticSearchFactory, SentryLoggerFactory sentryFactory)
        {
            _elasticSearchFactory = elasticSearchFactory;
            _sentryFactory = sentryFactory;
        }

        public ILogger CreateLogger(string loggerProvider, string categoryName)
        {
            switch (loggerProvider)
            {
                case "ElasticSearch":
                    return _elasticSearchFactory.CreateLogger(string.Empty, categoryName);
                case "Sentry":
                    return _sentryFactory.CreateLogger(string.Empty, categoryName);
                default:
                    throw new InvalidOperationException("Invalid LoggerFactory specified in app settings.");
            }
        }
    }
}
