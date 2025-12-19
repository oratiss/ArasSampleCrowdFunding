using Aras.SampleCrowdFunding.SharedKernel.Models;
using Aras.SampleCrowdFunding.SharedKernel.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.SharedKernel.Builders
{
    public class DomainPrizeCategoryBuilder : ReflectionBuilder<DomainPrizeCategory, DomainPrizeCategoryBuilder>
    {
        private readonly DomainPrizeCategoryBuilder _builderInstance;

        public bool IsDefault = PrizeCategoryConstantsProvider.IsDefault;
        public long PrizeId = PrizeCategoryConstantsProvider.PrizeId;
        public long CategoryId = PrizeCategoryConstantsProvider.CategoryId;

        public DomainPrizeCategoryBuilder()
        {
            _builderInstance = this;
        }


        public override DomainPrizeCategory Build()
        {
           var prizeCategory = new DomainPrizeCategory(CategoryId, PrizeId, IsDefault);
            return prizeCategory;
        }
    }
}
