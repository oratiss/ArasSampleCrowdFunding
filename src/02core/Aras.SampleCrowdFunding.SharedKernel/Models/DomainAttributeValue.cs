using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;

namespace Aras.SampleCrowdFunding.SharedKernel.Models
{
    public class DomainAttributeValue : DomainEntity<long>
    {
        public string Value { get; set; }
        public long PrizeId { get; set; }
        public long AttributeId { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreatorUserId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public long? ModifierUserId { get; set; }

        public DomainAttributeValue(string value, long prizeId, long attributeId, long creatorUserId, long? modifierUserId)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new DomainException(1, "Value is null, empty or white space.");
            Value = value;
            PrizeId = prizeId;
            AttributeId = attributeId;
            CreatorUserId = creatorUserId;
            ModifierUserId = modifierUserId;
        }
    }
}
