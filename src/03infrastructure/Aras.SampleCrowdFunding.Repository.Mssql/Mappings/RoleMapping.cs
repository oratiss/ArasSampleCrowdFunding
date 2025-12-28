using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;
using Atisaz.Core.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aras.SampleCrowdFunding.Repository.Mssql.Mappings;

public class RoleMapping() : EfMapping<WritableRole>("Roles", "USR")
{
    public override void Configure(EntityTypeBuilder<WritableRole> builder)
    {
        base.Configure(builder);

        builder.ToTable("Roles", "USR"); //should be checked is necessary or not -  constructor has it already!

        builder.HasKey(x => x.Id);
        builder.Property(e => e.Id).UseIdentityColumn(1001, 1);
        builder.Property(x => x.Name).HasMaxLength(100);
        builder.HasQueryFilter(e => !e.IsDeleted);
        builder.HasMany(x => x.UserRoles).WithOne(x => x.Role);
    }
}