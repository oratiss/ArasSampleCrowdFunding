using Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Providers;
using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate;
using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Builders;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Builders
{
    public class DomainLotteryBuilder : ReflectionBuilder<DomainLottery, DomainLotteryBuilder>
    {
        private readonly DomainLotteryBuilder _builderInstance;

        public long Id = DomainLotteryConstantProvider.Id;
        public long? UserTotalScore = DomainLotteryConstantProvider.UserTotalScore;
        public long Price = DomainLotteryConstantProvider.Price;
        public DateTime LotteryEvent = DomainLotteryConstantProvider.LotteryEvent;
        public long SejelUserId = DomainLotteryConstantProvider.SejelUserId;
        public long PrizeId = DomainLotteryConstantProvider.PrizeId;
        public long CreatorUserId = DomainLotteryConstantProvider.CreatorUserId;
        public long? ModifierUserId = DomainLotteryConstantProvider.ModifierUserId;
        public long CategoryLotteryId = DomainLotteryConstantProvider.CategoryLotteryId;

        public DomainPrize Prize { get; set; }

        public DomainLotteryBuilder(DomainPrizeBuilder domainPrizeBuilder)
        {
            Prize = domainPrizeBuilder.Build();

            _builderInstance = this;
        }

        public override DomainLottery Build()
        {
            var lottery = new DomainLottery(Id, SejelUserId, PrizeId, UserTotalScore, Price, CreatorUserId, ModifierUserId, CategoryLotteryId);
            return lottery;
        }
    }
}
