using Aras.SampleCrowdFunding.Application.Handlers.Users.CommandHandlers;
using Aras.SampleCrowdFunding.Application.Handlers.Users.QueryHandlers;
using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandsAndQueries;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Users;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Repository.Mongo.Repositories.Users;
using Aras.SampleCrowdFunding.Repository.Mssql.DataContexts;
using Aras.SampleCrowdFunding.Repository.Mssql.UnitOfWorks;
using Atisaz.Cache.Utilities.Configurations;
using Atisaz.Cache.Utilities.Redis;
using Atisaz.Core.Infra;
using Atisaz.Core.Infra.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


namespace Atisaz.CustomerClubMicroservice.GrpcService
{
    public static class ProgramExtension
    {
        public static void AddSqlServer(this IServiceCollection services, ConfigurationManager configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CrowdFundingDataContext>(options => options.UseSqlServer(connectionString));
            var serviceProvider = services.BuildServiceProvider();
            var dataContext = serviceProvider!.GetService<CrowdFundingDataContext>();
            services.AddSingleton<IEfDataContext>(dataContext!);
        }

        public static void AddUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<ICrowdFundingUnitOfWork, CrowdFundingUnitOfWork>();
        }

        public static void AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            var redisConfigSection = configuration.GetSection(nameof(RedisConfiguration));
            services.ConfigureRedisCache(new RedisConfiguration
            {
                Endpoint = redisConfigSection.GetValue<string>(nameof(RedisConfiguration.Endpoint)),
                InstanceName = redisConfigSection.GetValue<string>(nameof(RedisConfiguration.InstanceName)),
                Password = redisConfigSection.GetValue<string>(nameof(RedisConfiguration.Password))
            });
            services.ConfigureGlobalRedisCache(new RedisConfiguration
            {
                Endpoint = redisConfigSection.GetValue<string>(nameof(RedisConfiguration.Endpoint)),
                Password = redisConfigSection.GetValue<string>(nameof(RedisConfiguration.Password))
            });
        }

        public static void AddMongoDb(this IServiceCollection services, ConfigurationManager configuration)
        {
            var mongoSection = configuration.GetSection("MongoDB");
            services.Configure<MongoConfiguration>(mongoSection);
            var mongoConfig = services.BuildServiceProvider().GetService<IOptions<MongoConfiguration>>();

            var usersCollectionName = mongoSection.GetValue<string>("UsersCollectionName");
            services.AddSingleton<IReadableUserRepository>(new ReadableUserRepository(mongoConfig!, usersCollectionName!));

        }

        public static void AddApplicationCommandsAndQueries(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<AddUserCommand, CommandResponse<AddUserCommandResponse?>>), typeof(AddUserCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>), typeof(GetUserByIdQueryHandler));
        }



        //public static void ConfigureAndAddRayanServices(this WebApplicationBuilder builder, IConfiguration configuration)
        //{
        //    var rayanSection = configuration.GetSection("RayanConfig");
        //    builder.Services.Configure<RayanConfig>(rayanSection);
        //    builder.Services.AddHttpClient(rayanSection.GetValue<string>("HttpClientName")!, options =>
        //    {
        //        options.BaseAddress = new Uri(rayanSection.GetValue<string>("BaseUrl")!);
        //    });
        //    builder.Services.AddScoped<IRayanContractsService, RayanContractService>();
        //}
    }
}
