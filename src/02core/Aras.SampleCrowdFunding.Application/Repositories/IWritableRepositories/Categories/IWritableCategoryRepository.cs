using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Categories;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Categories
{
    public interface IWritableCategoryRepository : IWriteRepository<WritableCategory, long>
    {
        //Task<WritableCategory?> GetWithAttributeByIdAsync(long id, CancellationToken cancellationToken);
        //IEnumerable<WritableCategory>? GetCategoriesFullyWithAttributes();
    }
}
