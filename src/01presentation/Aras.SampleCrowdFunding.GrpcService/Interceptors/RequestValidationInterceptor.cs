using Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders;
using Aras.SampleCrowdFunding.UtilityService.RpcResponseStates;
using Atisaz.CustomerClubMicroservice.GrpcService.Interceptors.InterceptorExtensions;
using Atisaz.Grpc.Utilities;
using Grpc.Core;
using Grpc.Core.Interceptors;
using IRequestRpc = Aras.SampleCrowdFunding.UtilityService.RpcResponseStates.IRequestRpc;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;
namespace Atisaz.CustomerClubMicroservice.GrpcService.Interceptors
{
    public class RequestValidationInterceptor : Interceptor
    {
        private readonly string? _currentEnvironment;
        private readonly ILogger _logger;

        public RequestValidationInterceptor(ICustomLoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ElasticSearch", "Business");
            _currentEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var responseInstance = this.GetInstance(typeof(TResponse).FullName!);

            try
            {
                _logger.LogInformation($"Starting receiving call. Type: {MethodType.Unary}. Method: {context.Method}.");

                // Cast request to IRequestRpc and check validation
                var validationRequest = (IRequestRpc)request;
                if (validationRequest.IsValid(out List<string> errors))
                {
                    _logger.Log(LogLevel.Information, $"Request validity checked successfully - Method: {context.Method}.");
                    return continuation(request, context);
                }

                _logger.Log(LogLevel.Error, $"Request validation failed. - Method: {context.Method} - errors are: {string.Join(" || ", errors)}.");

                // Type check for responseInstance
                if (responseInstance is IResponseRpc response) // Assuming IResponseRpc defines Errors and ResponseStatus
                {
                    //if (_currentEnvironment == Environments.Development || _currentEnvironment == Environments.Staging)
                    //{
                    //    response.Errors.AddRange(errors);
                    //}
                    response.Errors.AddRange(errors);
                    response.ResponseStatus = (int)GrpcResponseStatusEnumeration.BadRequest;
                }
                else
                {
                    _logger.LogError("Response instance is not of the expected type.");
                    throw new InvalidCastException($"Expected response instance of type IResponseRpc, but got {responseInstance.GetType().FullName}");
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, $"Internal Server Error happened. {this.PrepareExceptionLogMessage(context.Host, context.Method)}{ex.Message}");

                // Type check for responseInstance
                if (responseInstance is IResponseRpc response)
                {
                    if (_currentEnvironment == Environments.Development || _currentEnvironment == Environments.Staging)
                    {
                        response.Errors.Add(ex.Message);
                        if (ex.StackTrace != null) response.Errors.Add(ex.StackTrace);
                        if (ex.InnerException != null)
                        {
                            response.Errors.Add(ex.InnerException.Message);
                            if (ex.InnerException.StackTrace != null) response.Errors.Add(ex.InnerException.StackTrace);
                        }
                    }
                    response.ResponseStatus = (int)RpcServiceStatus.InternalError;
                }
                else
                {
                    _logger.LogError("Response instance is not of the expected type.");
                    throw new InvalidCastException($"Expected response instance of type IResponseRpc, but got {responseInstance.GetType().FullName}");
                }
            }

            return Task.FromResult((TResponse)responseInstance!);
        }
    }
}
