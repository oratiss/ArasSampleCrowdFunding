using Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Builders
{
    public class DomainAttributeBuilder : ReflectionBuilder<DomainAttribute, DomainAttributeBuilder>
    {
        private readonly DomainAttributeBuilder _builderInstance;

        public string Name = AttributeConstantsProvider.Name;
        public long CategoryId = AttributeConstantsProvider.CategoryId;
        public long CreatorUserId = AttributeConstantsProvider.CreatorUserId;
        public long? ModifierUserId = AttributeConstantsProvider.ModifierUserId;

        public DomainAttributeBuilder()
        {
            _builderInstance = this;
        }

        public override DomainAttribute Build()
        {
            var domainAttribute = new DomainAttribute(Name, CategoryId, CreatorUserId, ModifierUserId);
            return domainAttribute;
        }
    }
}
