using Aras.SampleCrowdFunding.SharedKernel.Models;
using Aras.SampleCrowdFunding.SharedKernel.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.SharedKernel.Builders
{
    public class DomainOrderStateBuilder : ReflectionBuilder<DomainOrderState, DomainOrderStateBuilder>
    {
        private readonly DomainOrderStateBuilder _builderInstance;

        public string OrderStateType = OrderStateConstantProvider.OrderStateType;
        public DateTime CreateDate = OrderStateConstantProvider.CreateDate;
        public long CreatorUserId = OrderStateConstantProvider.CreatorUserId;
        public DateTime? ModifiedDate = OrderStateConstantProvider.ModifiedDate;
        public long? ModifierUserId = OrderStateConstantProvider.ModifierUserId;

        public DomainOrderStateBuilder()
        {
          _builderInstance = this;
        }

        public override DomainOrderState Build()
        {
            throw new NotImplementedException();
        }
    }
}
