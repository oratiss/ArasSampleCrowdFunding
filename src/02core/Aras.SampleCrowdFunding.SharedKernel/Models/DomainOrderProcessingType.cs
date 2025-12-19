using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.SharedKernel.Models
{
    public class DomainOrderProcessingType : DomainEntity<int>
    {
        public string ProcessingType { get; private set; } = null!;
        public List<DomainOrderState> OrderStates { get; set; }

        public DomainOrderProcessingType(string processingType)
        {
            ProcessingType = processingType;
        }
    }
}
