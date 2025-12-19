using Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Categories;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.UnitOFWorks;

public interface ICustomerClubUnitOfWork : IUnitOfWork
{
    public IWritableCategoryRepository WritableCategoryRepository { get; }
}