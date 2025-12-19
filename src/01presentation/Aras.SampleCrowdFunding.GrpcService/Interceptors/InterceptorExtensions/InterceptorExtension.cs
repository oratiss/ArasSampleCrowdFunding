using Grpc.Core.Interceptors;

namespace Atisaz.CustomerClubMicroservice.GrpcService.Interceptors.InterceptorExtensions
{
    public static class InterceptorExtension
    {
        public static string PrepareExceptionLogMessage(this Interceptor interceptor, string host, string method)
        {
            var logErrorMessage = $"Host and Port:{host}-Service and Method:{method}-ExceptionMessage: ";
            return logErrorMessage;
        }

        public static object? GetInstance(this Interceptor interceptor, string strFullyQualifiedName)
        {
            Type? type = Type.GetType(strFullyQualifiedName);
            var obj = type is not null ? Activator.CreateInstance(type) : null;
            return obj;
        }
    }
}
