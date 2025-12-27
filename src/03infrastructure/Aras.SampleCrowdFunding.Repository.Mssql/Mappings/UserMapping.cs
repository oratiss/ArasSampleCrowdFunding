using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;
using Atisaz.Core.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aras.SampleCrowdFunding.Repository.Mssql.Mappings
{
    public class UserMapping() : EfMapping<WritableUser>("Users", "USR")
    {
        public override void Configure(EntityTypeBuilder<WritableUser> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users", "USR"); //should be checked is necessary or not -  constructor has it already!

            builder.HasKey(x => x.Id);
            builder.Property(e => e.Id).UseIdentityColumn(1001, 1);
            builder.Property(x => x.FirstName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasMaxLength(50);

            builder.HasQueryFilter(e => !e.IsDeleted);

            builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
