using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Users;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Users;
using Atisaz.Core.Infra;
using Atisaz.Core.Infra.Configurations;
using Microsoft.Extensions.Options;

namespace Aras.SampleCrowdFunding.Repository.Mongo.Repositories.Users
{
    public class ReadableUserRepository: ReadRepository<ReadableUser, int>, IReadableUserRepository
    {
        public ReadableUserRepository(IOptions<MongoConfiguration> mongoConfig, string collectionName) : base(mongoConfig, collectionName)
        {
        }
    }
}
