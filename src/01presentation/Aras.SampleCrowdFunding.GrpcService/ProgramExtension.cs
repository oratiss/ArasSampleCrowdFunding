using Aras.SampleCrowdFunding.Application.Handlers.Categories.CommandHandlers.Categories;
using Aras.SampleCrowdFunding.Application.Handlers.Categories.QueryHandlers.Categories;
using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.AddUsecases;
using Aras.SampleCrowdFunding.Application.Models.Categories.DeleteUsecases;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFunding.Application.Models.Categories.UpdateUsecases;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Categories;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices;
using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Abstractions;
using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Configs;
using Aras.SampleCrowdFunding.Repository.Mongo.Repositories.Prize;
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
            services.AddDbContext<CustomerClubDataContext>(options => options.UseSqlServer(connectionString));
            var serviceProvider = services.BuildServiceProvider();
            var dataContext = serviceProvider!.GetService<CustomerClubDataContext>();
            services.AddSingleton<IEfDataContext>(dataContext!);
        }

        public static void AddUnitOfWorks(this IServiceCollection services)
        {
            services.AddScoped<ICustomerClubUnitOfWork, CustomerClubUnitOfWork>();
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

            var categoryCollectionName = mongoSection.GetValue<string>("CategoriesCollectionName");
            services.AddSingleton<IReadableCategoryRepository>(new ReadableCategoryRepository(mongoConfig!, categoryCollectionName!));

        }

        public static void AddApplicationCommandsAndQueries(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRequestHandler<AddCategoryCommand, AddCategoryCommandResponse>), typeof(AddCategoryCommandHandler));
            services.AddScoped(typeof(IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse>), typeof(UpdateCategoryCommandHandler));
            services.AddScoped(typeof(IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>), typeof(DeleteCategoryCommandHandler));
            services.AddScoped(typeof(IRequestHandler<GetCategoriesQuery, QueryResponse<CategoriesQueryResponse?>>), typeof(GetCategoryQueryHandler));
            services.AddScoped(typeof(IRequestHandler<GetCategoryByIdQuery, CategoryQueryResponse>), typeof(GetCategoryByIdQueryHandler));
        }



        public static void ConfigureAndAddRayanServices(this WebApplicationBuilder builder, IConfiguration configuration)
        {
            var rayanSection = configuration.GetSection("RayanConfig");
            builder.Services.Configure<RayanConfig>(rayanSection);
            builder.Services.AddHttpClient(rayanSection.GetValue<string>("HttpClientName")!, options =>
            {
                options.BaseAddress = new Uri(rayanSection.GetValue<string>("BaseUrl")!);
            });
            builder.Services.AddScoped<IRayanContractsService, RayanContractService>();
        }
    }
}
