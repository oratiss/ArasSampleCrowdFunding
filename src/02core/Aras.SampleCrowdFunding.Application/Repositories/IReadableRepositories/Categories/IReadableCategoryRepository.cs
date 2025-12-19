using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Categories;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Categories
{
    public interface IReadableCategoryRepository : IReadRepository<ReadableCategory, long>
    {

    }
}
