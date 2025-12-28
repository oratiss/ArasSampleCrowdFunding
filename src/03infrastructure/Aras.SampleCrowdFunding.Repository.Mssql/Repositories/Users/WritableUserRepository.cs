using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;
using Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Users;
using Aras.SampleCrowdFunding.Repository.Mssql.DataContexts;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Repository.Mssql.Repositories.Users
{
    public class WritableUserRepository(IEfDataContext context)
        : WriteRepository<WritableUser, int, CrowdFundingDataContext>(context), IWritableUserRepository;
}
