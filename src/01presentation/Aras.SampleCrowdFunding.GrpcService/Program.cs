using Aras.SampleCrowdFunding.ApplicationContract;
using Aras.SampleCrowdFunding.GrpcService.ServiceProviders.LoggerProviders;
using Aras.SampleCrowdFunding.GrpcService.Services;
using Atisaz.CustomerClubMicroservice.GrpcService;
using Atisaz.CustomerClubMicroservice.GrpcService.Configs;
using Atisaz.CustomerClubMicroservice.GrpcService.Interceptors;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
}
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureEndpointDefaults(c => c.Protocols = HttpProtocols.Http2);
});

var configuration = builder.Configuration;


MapsterConfig.RegisterMapsterConfiguration();

builder.Services.AddSqlServer(configuration);
builder.Services.AddUnitOfWorks();

builder.Services.AddMongoDb(configuration);

builder.Services.AddRedisCache(configuration);

builder.Services.AddSingleton<ElasticSearchLoggerFactory>();
builder.Services.AddSingleton<SentryLoggerFactory>();

builder.Services.AddSingleton<CustomLoggerFactory>();
builder.Services.AddSingleton<ICustomLoggerFactory>(provider =>
{
    var customLoggerFactory = provider.GetRequiredService<CustomLoggerFactory>();
    return customLoggerFactory;
});


builder.Services.AddSingleton<ServerLoggerInterceptor>();
builder.Services.AddSingleton<RequestValidationInterceptor>();
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ServerLoggerInterceptor>();
    options.Interceptors.Add<RequestValidationInterceptor>();
});

//this was used for fetching user data with user grpc client - not required in our scenario.
//It is kept for a future use.
//builder.Services.AddGrpcClients(configuration);

builder.Services.AddApplicationCommandsAndQueries();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

//builder.Services.AddScoped<IWheelOfLuckService, WheelOfLuckService>();

builder.Services.AddMemoryCache();
builder.ConfigureAndAddRayanServices(configuration);
//builder.Services.AddScoped<ICreditContractValidator, RayanCreditContractValidator>();

var app = builder.Build();

//app.UseElasticApm(configuration);
// Configure the HTTP request pipeline.

app.MapGrpcService<SampleCrowdFundingService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();



