using Atisaz.SejelMicroService.Atisaz.SejelMicroService.GrpcService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aras.SampleCrowdFunding.Common.SejelGRpcClient
{
    public static class GrpcClientRegistration
    {
        public static void AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<Sejel_MainServiceRpc.Sejel_MainServiceRpcClient>(options =>
            {
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
                var url = configuration.GetValue<string>("GrpcServices:SejelGrpc:Url")!;
                options.Address = new Uri(url);
            });
        }
    }
}
