using Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Builders
{
    public class DomainCategoryLotteryBuilder : ReflectionBuilder<DomainLotteryCategory, DomainCategoryLotteryBuilder>
    {
        private readonly DomainCategoryLotteryBuilder _builderInstance;

        public long Id = DomainLotteryCategoryConstantProvider.Id;
        public string Name = DomainLotteryCategoryConstantProvider.Name;
        public long CreatorUserId = DomainLotteryCategoryConstantProvider.CreatorUserId;
        public long? ModifierUserId = DomainLotteryCategoryConstantProvider.ModifierUserId;


        public DomainCategoryLotteryBuilder()
        {
            _builderInstance = this;
        }

        public override DomainLotteryCategory Build()
        {
            var domainLotteryCategory = new DomainLotteryCategory(Id, Name, CreatorUserId, ModifierUserId);
            return domainLotteryCategory;
        }
    }
}
