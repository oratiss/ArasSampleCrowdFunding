using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Providers;
using Aras.SampleCrowdFunding.SharedKernel.Builders;
using Aras.SampleCrowdFunding.SharedKernel.Models;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Builders
{
    public class DomainPrizeBuilder : ReflectionBuilder<DomainPrize, DomainPrizeBuilder>
    {
        private readonly DomainPrizeBuilder _builderInstance;

        public long Id = PrizeConstantsProvider.Id;
        public string Name = PrizeConstantsProvider.Name;
        public string? ShortDescription = PrizeConstantsProvider.ShortDescription;
        public string? LongDescription = PrizeConstantsProvider.LongDescription;
        public long Price = PrizeConstantsProvider.Price;
        public int Quantity = PrizeConstantsProvider.Quantity;
        public bool IsCachable = PrizeConstantsProvider.IsCachable;
        public bool IsCreditable = PrizeConstantsProvider.IsCreditable;
        public bool IsComngSoon = PrizeConstantsProvider.IsComingSoon;
        public bool IsEnabaledOnSite = PrizeConstantsProvider.IsEnabaledOnSite;
        //public DateTime CreateDate = PrizeConstantsProvider.CreateDate;
        public long CreatorUserId = PrizeConstantsProvider.CreatorUserId;
        // public DateTime? ModifiedDate = PrizeConstantsProvider.ModifiedDate;
        public long? ModifierUserId = PrizeConstantsProvider.ModifierUserId;
        public int OrderProcessingTypeId = PrizeConstantsProvider.OrderProcessingTypeId;
        public bool IsForLuck = PrizeConstantsProvider.IsForLuck;
        public double? WheelChance = PrizeConstantsProvider.WheelChance;
        public int? Priority = PrizeConstantsProvider.Priority;
        public bool IsForLottery = PrizeConstantsProvider.IsForLottery;

        public List<DomainPrizeCategory>? PrizeCategories;
        public List<PrizeFile>? PrizeFiles;
        public List<DomainDiscount>? DomainDiscounts;
        public List<DomainPrizeCategoryLottery>? DomainPrizeCategoryLotteries;

        public DomainPrizeBuilder(List<DomainPrizeCategoryBuilder>? domainPrizeCategoriesBuilder, List<PrizeFileBuilder>? prizeFilesBuilder, List<DomainDiscountBuilder>? domainDiscountsBuilder, List<DomainPrizeCategoryLotteryBuilder>? domainPrizeCategoryLotteries)
        {
            if (domainPrizeCategoriesBuilder is not null && domainPrizeCategoriesBuilder.Any())
            {
                PrizeCategories = domainPrizeCategoriesBuilder.Select(x => x.Build()).ToList();
            }

            if (prizeFilesBuilder is not null && prizeFilesBuilder.Any())
            {
                PrizeFiles = prizeFilesBuilder.Select(x => x.Build()).ToList();
            }

            if (domainDiscountsBuilder is not null && domainDiscountsBuilder.Any())
            {
                DomainDiscounts = domainDiscountsBuilder.Select(x => x.Build()).ToList();
            }

            if (domainPrizeCategoryLotteries is not null && domainPrizeCategoryLotteries.Any())
            {
                DomainPrizeCategoryLotteries = domainPrizeCategoryLotteries.Select(x => x.Build()).ToList();
            }

            _builderInstance = this;
        }

        public override DomainPrize Build()
        {
            var domainPrize = new DomainPrize(Id, Name, ShortDescription, LongDescription, Price, Quantity, IsCachable, IsCreditable, CreatorUserId, ModifierUserId, IsComngSoon, PrizeCategories!, PrizeFiles!,
            OrderProcessingTypeId, DomainDiscounts, IsEnabaledOnSite, DomainPrizeCategoryLotteries, IsForLuck, WheelChance, Priority, IsForLottery );
            return domainPrize;
        }
    }
}
