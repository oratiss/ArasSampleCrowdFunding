using Aras.SampleCrowdFunding.SharedKernel.Models;
using Aras.SampleCrowdFunding.SharedKernel.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.SharedKernel.Builders
{
    public class DomainAttributeValueBuilder : ReflectionBuilder<DomainAttributeValue, DomainAttributeValueBuilder>
    {
        private readonly DomainAttributeValueBuilder _builderInstance;

        public string Value = AttributeValueConstantsProvider.Value;
        public long PrizeId = AttributeValueConstantsProvider.PrizeId;
        public long AttributeId = AttributeValueConstantsProvider.AttributeId;
        public DateTime CreateDate = AttributeValueConstantsProvider.CreateDate;
        public long CreatorUserId = AttributeValueConstantsProvider.CreatorUserId;
        public DateTime? ModifiedDate = AttributeValueConstantsProvider.ModifiedDate;
        public long? ModifierUserId = AttributeValueConstantsProvider.ModifierUserId;

        public DomainAttributeValueBuilder()
        {
            _builderInstance = this;
        }

        public override DomainAttributeValue Build()
        {
            var domainAttribute = new DomainAttributeValue(Value, PrizeId, AttributeId, CreatorUserId, ModifierUserId);
            return domainAttribute;
        }
    }
}
