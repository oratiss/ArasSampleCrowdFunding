using Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Builders
{
    public class DomainCategoryBuilder : ReflectionBuilder<DomainCategory, DomainCategoryBuilder>
    {
        private readonly DomainCategoryBuilder _builderInstance;

        public long Id = CategoryConstantsProvider.Id;
        public long ParentId = CategoryConstantsProvider.ParentId;
        public string Name = CategoryConstantsProvider.Name;
        public long? CreatorUserId = CategoryConstantsProvider.CreatorUserId;
        public long? ModifierUserId = CategoryConstantsProvider.ModifierUserId;
        public bool IsDeleted = CategoryConstantsProvider.IsDeleted;
        public List<DomainAttribute>? DomainAttributes;

        public DomainCategoryBuilder(/*List<DomainAttributeBuilder>? domainAttributeBuilders*/)
        {
            //if (domainAttributeBuilders is not null && domainAttributeBuilders.Any())
            //{
            //    DomainAttributes = domainAttributeBuilders.Select(x => x.Build()).ToList();
            //}
            _builderInstance = this;
        }

        public override DomainCategory Build()
        {
            var domainCtegory = new DomainCategory(Id, ParentId, Name, CreatorUserId, ModifierUserId, IsDeleted, DomainAttributes);
            return domainCtegory;
        }
    }
}
