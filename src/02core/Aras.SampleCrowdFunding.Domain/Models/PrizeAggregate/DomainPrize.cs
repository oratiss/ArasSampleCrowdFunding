using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.Models;

namespace Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate
{
    public class DomainPrize : AggregateRoot<long>
    {
        public string Name { get; set; }
        public string? ShortDescription { get; private set; }
        public string? LongDescription { get; private set; }
        public long Price { get; private set; }
        public int Quantity { get; private set; }
        public bool IsCachable { get; private set; }
        public bool IsCreditable { get; private set; }
        public bool IsPublished { get; private set; }
        public bool IsEnabaledOnSite { get; private set; }
        public bool? IsComingSoon { get; private set; }
        public long CreatorUserId { get; private set; }
        public long? ModifierUserId { get; private set; }
        public int OrderProcessingTypeId { get; private set; }
        public bool IsForLuck { get; private set; }
        public double? WheelChance { get; private set; }
        public int? Priority { get; private set; }
        public bool IsForLottery { get; private set; }

        public List<DomainPrizeCategory>? PrizeCategories { get; private set; }
        public List<PrizeFile> PrizeFiles { get; private set; }
        public List<DomainDiscount>? DomainDiscounts { get; private set; }
        public List<DomainPrizeCategoryLottery>? DomainPrizeCategoryLotteries { get; private set; }

        public DomainPrize(long id, string name, string? shortDescription, string? longDescription,
           long price, int quantity, bool isCachable, bool isCreditable,
           long creatorUserId, long? modifierUserId, bool? isComingSoon, List<DomainPrizeCategory>? prizeCategories, List<PrizeFile> prizeFiles, int orderProcessingTypeId, 
           List<DomainDiscount>? domainDiscounts, bool isEnabaledOnSite, List<DomainPrizeCategoryLottery>? domainPrizeCategoryLotteries, bool isForLuck, double? wheelChance, int? priority, bool isForLottery)
        {
            //if (prizeCategories.Count(d => d.IsDefault = true) != 1) throw new DomainException(2, "IsDefault Equal True For Category Just Has One Count ");

            Id = id;
            Name = name;
            ShortDescription = shortDescription;
            LongDescription = longDescription;
            CreatorUserId = creatorUserId;
            ModifierUserId = modifierUserId;
            Price = price;
            Quantity = quantity;
            IsCachable = isCachable;
            IsCreditable = isCreditable;
            IsComingSoon = isComingSoon;
            PrizeCategories = prizeCategories;
            PrizeFiles = prizeFiles;
            OrderProcessingTypeId = orderProcessingTypeId;
            DomainDiscounts = domainDiscounts;
            IsEnabaledOnSite = isEnabaledOnSite;
            DomainPrizeCategoryLotteries = domainPrizeCategoryLotteries;
            IsForLuck = isForLuck;
            WheelChance = wheelChance;
            Priority = priority;
            IsForLottery = isForLottery;
        }
    }
}
