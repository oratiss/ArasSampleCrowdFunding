using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;
using Atisaz.Core.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aras.SampleCrowdFunding.Repository.Mssql.Mappings;

public class UserRoleMapping() : EfMapping<WritableUserRole>("UserRoles", "USR")
{
    public override void Configure(EntityTypeBuilder<WritableUserRole> builder)
    {
        base.Configure(builder);

        builder.ToTable("Users", "USR"); //should be checked is necessary or not -  constructor has it already!

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).UseIdentityColumn(1001, 1);

        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.HasOne(x => x.User).WithMany(u => u.UserRoles).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.Role).WithMany(u => u.UserRoles).HasForeignKey(x => x.RoleId);
    }
}