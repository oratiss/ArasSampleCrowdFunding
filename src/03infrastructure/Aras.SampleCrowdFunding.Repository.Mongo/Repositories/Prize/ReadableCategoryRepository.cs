using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Categories;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Categories;
using Atisaz.Core.Infra;
using Atisaz.Core.Infra.Configurations;
using Microsoft.Extensions.Options;

namespace Aras.SampleCrowdFunding.Repository.Mongo.Repositories.Prize
{
    public class ReadableCategoryRepository : ReadRepository<ReadableCategory, long>, IReadableCategoryRepository
    {
        public ReadableCategoryRepository(IOptions<MongoConfiguration> mongoConfig, string collectionName) : base(mongoConfig, collectionName)
        {
        }
    }
}
