using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;

public class WritableRole: IEntity<int>, IAuditableEntity<int>, ISoftDeleteEnabled<int>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public int RoleIdrId { get; set; }
    public DateTime CreateDate { get; set; }
    public long CreatorUserId { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public long? ModifierUserId { get; set; }
    public List<WritableUserRole>? UserRoles { get; set; }
}