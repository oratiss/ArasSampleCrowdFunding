using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate
{
    public class DomainLotteryCategory : AggregateRoot<long>
    {
        public long Id { get; private set; }
        public string Name { get; private set; } = null!;
        public long? CreatorUserId { get; private set; }
        public long? ModifierUserId { get; private set; }

        public DomainLotteryCategory(long id, string name, long? creatorUserId, long? modifierUserId)
        {
            Id = id;
            Name = name;
            CreatorUserId = creatorUserId;
            ModifierUserId = modifierUserId;
        }
    }
}
