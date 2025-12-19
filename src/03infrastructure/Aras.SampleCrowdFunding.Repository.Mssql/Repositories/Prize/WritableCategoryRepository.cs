using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Categories;
using Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Categories;
using Aras.SampleCrowdFunding.Repository.Mssql.DataContexts;
using Atisaz.Core.Infra;
using Microsoft.EntityFrameworkCore;

namespace Aras.SampleCrowdFunding.Repository.Mssql.Repositories.Prize
{
    public class WritableCategoryRepository : WriteRepository<WritableCategory, long, CustomerClubDataContext>, IWritableCategoryRepository
    {
        public WritableCategoryRepository(IEfDataContext context) : base(context)
        {
        }

        //public async Task<WritableCategory?> GetWithAttributeByIdAsync(long id, CancellationToken cancellationToken)
        //{
        //    var category = await DataSource.Include(x => x.Attributes).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        //    return category;
        //}

        //public IEnumerable<WritableCategory>? GetCategoriesFullyWithAttributes()
        //{
        //    var categories =  DataSource.Include(x => x.Attributes)!.ThenInclude(y => y.AttributeValues);
        //    return categories.AsEnumerable();
        //}
    }
}
