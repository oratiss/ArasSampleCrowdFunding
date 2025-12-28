using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Users
{
    public interface IWritableUserRepository: IWriteRepository<WritableUser, int>
    {
    }
}
