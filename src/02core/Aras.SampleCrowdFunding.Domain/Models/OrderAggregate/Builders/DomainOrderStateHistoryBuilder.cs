using Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Builders
{
    public class DomainOrderStateHistoryBuilder : ReflectionBuilder<DomainOrderStateHistory, DomainOrderStateHistoryBuilder>
    {
        private readonly DomainOrderStateHistoryBuilder _builderInstance;

        public string OrderStateHistoryType = OrderStateHistoryConstantProvider.OrderStateHistoryType;
        public long OrderId = OrderStateHistoryConstantProvider.OrderId;

        public override DomainOrderStateHistory Build()
        {
            var orderStateHistory = new DomainOrderStateHistory(OrderStateHistoryType, OrderId);
            return orderStateHistory;
        }
    }
}
