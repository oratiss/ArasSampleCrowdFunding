using Aras.SampleCrowdFunding.SharedKernel.Models;
using Aras.SampleCrowdFunding.SharedKernel.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.SharedKernel.Builders
{
    public class DomainPrizeCategoryLotteryBuilder : ReflectionBuilder<DomainPrizeCategoryLottery, DomainPrizeCategoryLotteryBuilder>
    {
        private readonly DomainPrizeCategoryLotteryBuilder _builderInstance;

        public long PrizeId = DomainPrizeCategoryLotteryConstantsProvider.PrizeId;
        public long CategoryLotteryId = DomainPrizeCategoryLotteryConstantsProvider.CategoryLotteryId;

        public DomainPrizeCategoryLotteryBuilder()
        {
            _builderInstance = this;
        }

        public override DomainPrizeCategoryLottery Build()
        {
            var prizeCategoryLottery = new DomainPrizeCategoryLottery(CategoryLotteryId, PrizeId);
            return prizeCategoryLottery;

        }
    }
}
