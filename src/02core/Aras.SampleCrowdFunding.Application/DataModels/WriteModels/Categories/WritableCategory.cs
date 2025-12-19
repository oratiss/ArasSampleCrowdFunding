using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Categories
{
    public class WritableCategory : IEntity<long>, IAuditableEntity<long>, ISoftDeleteEnabled<long>
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
        public long CreatorUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifierUserId { get; set; }


    }
}
