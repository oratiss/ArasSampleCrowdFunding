using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Categories;
using Atisaz.Core.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aras.SampleCrowdFunding.Repository.Mssql.Mappings
{
    public class CategoryMapping : EfMapping<WritableCategory>
    {
        public CategoryMapping() : base("Categories", "dbo")
        {
        }

        public override void Configure(EntityTypeBuilder<WritableCategory> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).UseIdentityColumn(1001, 1);

            builder.HasQueryFilter(e => !e.IsDeleted);

            //builder.HasMany(x => x.Attributes).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
            //builder.HasMany(x => x.PrizeCategories).WithOne(x => x.Category).HasForeignKey(x => x.CategoryId);
        }
    }
}
