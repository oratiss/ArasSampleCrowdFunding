using Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders;
using Atisaz.CustomerClubMicroservice.GrpcService.Interceptors.InterceptorExtensions;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Atisaz.CustomerClubMicroservice.GrpcService.Interceptors
{
    public class ServerLoggerInterceptor : Interceptor
    {
        private readonly ILogger _logger;
        private readonly IHostEnvironment _environment;

        public ServerLoggerInterceptor(ICustomLoggerFactory loggerFactory, IHostEnvironment environment)
        {
            _logger = loggerFactory.CreateLogger("Sentry","System");
            _environment = environment;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var responseInstance = this.GetInstance(typeof(TResponse).FullName!);
            try
            {
                var result = await continuation(request, context);
                return result;
            }
            catch (Exception ex)
            {
                var logMessage = $"{PrepareExceptionLogMessage(context.Host, context.Method)}{ex.Message}";
                if (ex.InnerException is not null
                    && (_environment.IsDevelopment() || _environment.IsStaging()))
                {
                    logMessage = logMessage + "-InnerException: " + $"{ex.InnerException.Message}"+"-StackTrace: "+$"{ex.StackTrace ?? "no stack trace provided."}";
                }
                _logger.Log(LogLevel.Error, logMessage);
            }

            return (TResponse)responseInstance!;
        }

        protected string PrepareExceptionLogMessage(string host, string method)
        {
            var logErrorMessage = $"Host and Port:{host}-Service and Method:{method}-ExceptionMessage: ";
            return logErrorMessage;
        }
    }
}
