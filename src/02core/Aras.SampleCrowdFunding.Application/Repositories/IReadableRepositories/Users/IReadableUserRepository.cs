using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Users;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Users
{
    public interface IReadableUserRepository : IReadRepository<ReadableUser, int>
    {
    }
}
