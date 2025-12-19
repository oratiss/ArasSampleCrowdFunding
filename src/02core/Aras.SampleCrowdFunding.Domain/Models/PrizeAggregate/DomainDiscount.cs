using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate
{
    public class DomainDiscount : DomainEntity<long>
    {
        public long? PrizeId { get; set; }
        public string? DiscountCode { get; set; } 
        public bool IsSold { get; set; }

        public DomainDiscount(long? prizeId, string? discountCode, bool isSold)
        {
            PrizeId = prizeId;
            DiscountCode = discountCode;
            IsSold = isSold;
        }
    }
}
