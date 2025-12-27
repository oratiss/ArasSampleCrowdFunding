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

// Configure Kestrel to support both HTTP/1.1 (for Swagger) and HTTP/2 (for gRPC)
builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureEndpointDefaults(c => c.Protocols = HttpProtocols.Http1AndHttp2);
});

var configuration = builder.Configuration;

// Mapster Configuration
MapsterConfig.RegisterMapsterConfiguration();

// Database and Cache Services
builder.Services.AddSqlServer(configuration);
builder.Services.AddUnitOfWorks();
builder.Services.AddMongoDb(configuration);
builder.Services.AddRedisCache(configuration);

// Logging Services
builder.Services.AddSingleton<ElasticSearchLoggerFactory>();
builder.Services.AddSingleton<SentryLoggerFactory>();
builder.Services.AddSingleton<CustomLoggerFactory>();
builder.Services.AddSingleton<ICustomLoggerFactory>(provider =>
{
    var customLoggerFactory = provider.GetRequiredService<CustomLoggerFactory>();
    return customLoggerFactory;
});

// Interceptors
builder.Services.AddSingleton<ServerLoggerInterceptor>();
builder.Services.AddSingleton<RequestValidationInterceptor>();

// gRPC Services
builder.Services.AddGrpc(options =>
{
    options.Interceptors.Add<ServerLoggerInterceptor>();
    options.Interceptors.Add<RequestValidationInterceptor>();
}).AddJsonTranscoding();

// gRPC Reflection for Swagger
builder.Services.AddGrpcReflection();

// gRPC Swagger Integration
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Sample CrowdFunding gRPC API", Version = "v1" });
});

// Application Services
builder.Services.AddApplicationCommandsAndQueries();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddMemoryCache();
//builder.ConfigureAndAddRayanServices(configuration);

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
    });
});

var app = builder.Build();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample CrowdFunding gRPC API V1");
    });
}

// Enable CORS before gRPC Web
app.UseCors();

// Enable gRPC-Web with default settings
app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

app.UseRouting();

// Map gRPC Services (no need to duplicate)
app.MapGrpcService<SampleCrowdFundingService>();

// Map gRPC Reflection Service (for tools like grpcurl and Swagger)
if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Root endpoint
app.MapGet("/", () => Results.Json(new
{
    message = "gRPC Service is running",
    endpoints = new[]
    {
        "/swagger - API Documentation",
        "gRPC endpoints available via gRPC client or gRPC-Web"
    }
}));

app.Run();