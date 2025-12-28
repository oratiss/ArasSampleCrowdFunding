using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.CategoryAggregate
{
    public class DomainCategory : AggregateRoot<long>
    {
        public long? ParentId { get; private set; }
        public string Name { get; private set; }
        public long? CreatorUserId { get; private set; }
        public long? ModifierUserId { get; private set; }
        public bool IsDeleted { get; set; }

        public List<DomainAttribute>? DomainAttributes { get; private set; }


        public DomainCategory(long id, long? parentId, string name, long? creatorUserId, long? modifierUserId, bool isDeleted, List<DomainAttribute>? domainAttributes)
        {
            Id = id;
            ParentId = parentId;
            Name = name;
            CreatorUserId = creatorUserId;
            ModifierUserId = modifierUserId;
            IsDeleted = isDeleted;
            DomainAttributes = domainAttributes;
        }
    }
}
