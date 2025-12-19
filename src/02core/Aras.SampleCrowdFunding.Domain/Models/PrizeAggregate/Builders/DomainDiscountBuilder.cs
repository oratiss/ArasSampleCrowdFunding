using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Builders
{
    public class DomainDiscountBuilder : ReflectionBuilder<DomainDiscount, DomainDiscountBuilder>
    {
        private readonly DomainDiscountBuilder _builderInstance;

        public long? PrizeId = DomainDiscountConstantProvider.PrizeId;
        public string? DiscountCode = DomainDiscountConstantProvider.DiscountCode;
        public bool IsSold = DomainDiscountConstantProvider.IsSold;

        public override DomainDiscount Build()
        {
            var discount = new DomainDiscount(PrizeId, DiscountCode, IsSold);
            return discount;
        }
    }
}
