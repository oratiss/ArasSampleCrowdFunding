using Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Users;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.UnitOFWorks;

public interface ICrowdFundingUnitOfWork : IUnitOfWork
{
    public IWritableUserRepository WritableUserRepository { get; set; }

}