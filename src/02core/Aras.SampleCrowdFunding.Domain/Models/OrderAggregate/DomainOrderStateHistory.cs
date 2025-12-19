using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate
{
    public class DomainOrderStateHistory : DomainEntity<long>
    {
        public string OrderStateHistoryType { get; set; }
        public long OrderId { get; set; }

        public DomainOrderStateHistory(string orderStateHistoryType, long orderId)
        {
            OrderStateHistoryType = orderStateHistoryType;
            OrderId = orderId;

        }
    }
}
