using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.SharedKernel.Models
{
    public class DomainPrizeCategory : DomainEntity<long>
    {
        public long CategoryId { get; set; } 
        public long PrizeId { get; set; }
        public bool IsDefault { get; set; }

        public DomainPrizeCategory(long categoryId, long prizeId, bool isDefault)
        {
            CategoryId = categoryId;
            PrizeId = prizeId;
            IsDefault = isDefault;
        }
    }
}
