using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate;
using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate
{
    public class DomainLottery : DomainEntity<long>
    {
        public long Id { get; private set; }
        public long SejelUserId { get; private set; }
        public long PrizeId { get; private set; }
        public long CategoryLotteryId { get; private set; }
        public DateTime LotteryEvent { get; private set; }
        public long? WinnerId { get; private set; }
        public long? WinningMethode { get; private set; }
        public long? UserTotalScore { get; set; }
        public long Price { get; private set; }
        public long CreatorUserId { get; private set; }
        public long? ModifierUserId { get; private set; }

        public DomainPrize DomainPrize { get; set; }

        public DomainLottery(long id, long sejelUserId, long prizeId, long? userTotalScore, long price, long creatorUserId, long? modifierUserId, long categoryLotteryId)
        {
            if (userTotalScore < price) throw new DomainException(1004, "Score is Lower Than The Price");
            Price = price;
            Id = id;
            SejelUserId = sejelUserId;
            PrizeId = prizeId;
            CreatorUserId = creatorUserId;
            ModifierUserId = modifierUserId;
            CategoryLotteryId = categoryLotteryId;
        }
    }
}
