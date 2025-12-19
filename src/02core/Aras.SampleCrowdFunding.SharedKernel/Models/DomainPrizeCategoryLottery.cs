using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.SharedKernel.Models
{
    public class DomainPrizeCategoryLottery : DomainEntity<long>
    {
        public long CategoryLotteryId { get; set; }
        public long PrizeId { get; set; }

        public DomainPrizeCategoryLottery(long categoryLotteryId, long prizeId)
        {
            CategoryLotteryId = categoryLotteryId;
            PrizeId = prizeId;
        }
    }
}
