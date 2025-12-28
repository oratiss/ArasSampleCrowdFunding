using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;

public class WritableUserRole: IEntity<long>, IAuditableEntity<long>, ISoftDeleteEnabled<long>
{
    public long Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public DateTime CreateDate { get; set; }
    public long CreatorUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifierUserId { get; set; }
    public WritableUser User { get; set; } = null!;
    public WritableRole Role { get; set; } = null!;
}