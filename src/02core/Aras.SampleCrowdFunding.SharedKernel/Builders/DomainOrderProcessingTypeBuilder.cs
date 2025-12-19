using Aras.SampleCrowdFunding.SharedKernel.Models;
using Aras.SampleCrowdFunding.SharedKernel.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.SharedKernel.Builders
{
    public class DomainOrderProcessingTypeBuilder : ReflectionBuilder<DomainOrderProcessingType, DomainOrderProcessingTypeBuilder>
    {
        private readonly DomainOrderProcessingTypeBuilder _builderInstance;

        public string ProcessingType = OrderProcessingTypeConstants.ProcessingType;

        public DomainOrderProcessingTypeBuilder()
        {
            _builderInstance = this;
        }

        public override DomainOrderProcessingType Build()
        {
            var processType = new DomainOrderProcessingType(ProcessingType);
           return processType;
        }
    }
}
