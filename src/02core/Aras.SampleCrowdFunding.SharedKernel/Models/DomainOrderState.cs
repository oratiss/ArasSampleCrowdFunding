using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.SharedKernel.Models
{
    public class DomainOrderState : DomainEntity<long>
    {
        public string OrderStateType { get; set; }

        public DomainOrderState(string orderStateType)
        {
            OrderStateType = orderStateType;
        }
    }
}
