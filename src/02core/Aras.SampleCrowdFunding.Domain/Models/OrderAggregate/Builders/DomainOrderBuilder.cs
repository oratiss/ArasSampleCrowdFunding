using Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Providers;
using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate;
using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Builders;
using Aras.SampleCrowdFunding.DomainContract.CreditValidationProviders;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate.Builders
{
    public class DomainOrderBuilder : ReflectionBuilder<DomainOrder, DomainOrderBuilder>
    {
        //public readonly ICreditContractValidator CreditContractValidator;
        private readonly DomainOrderBuilder _builderInstance;

        public long Id = OrderConstantProvider.Id;
        public long PrizeId = OrderConstantProvider.PrizeId;
        public long SejelUserId = OrderConstantProvider.SejelUserId;
        public string? OrderNumber = OrderConstantProvider.OrderNumber;
        public long Price = OrderConstantProvider.Price;
        public long OrderStateId = OrderConstantProvider.OrderStateId;
        public DateTime OrderDateTime = OrderConstantProvider.OrderDateTime;
        public DateTime CreateDate = OrderConstantProvider.CreateDate;
        public long CreatorUserId = OrderConstantProvider.CreatorUserId;
        public DateTime? ModifiedDate = OrderConstantProvider.ModifiedDate;
        public long? ModifierUserId = OrderConstantProvider.ModifierUserId;
        public long? UserTotalScore = OrderConstantProvider.UserTotalScore;
        public int Quantity = OrderConstantProvider.StockQuantity;
        public string? FirstName;
        public string? LastName;
        public string? OrderDetails;

        public List<DomainOrderStateHistory>? OrderStateHistories;

        public DomainPrize Prize { get; set; }

        public DomainOrderBuilder(List<DomainOrderStateHistoryBuilder>? domainOrderStateHistories, DomainPrizeBuilder domainPrizeBuilder
            //, ICreditContractValidator creditContractValidator
            )
        {
            //CreditContractValidator = creditContractValidator;
            Prize = domainPrizeBuilder.Build();

            if (domainOrderStateHistories is not null && domainOrderStateHistories.Any())
            {
                OrderStateHistories = domainOrderStateHistories.Select(x => x.Build()).ToList();
            }
            _builderInstance = this;
        }

        public override DomainOrder Build()
        {
            var order = new DomainOrder(/*CreditContractValidator,*/ Id, PrizeId, SejelUserId, OrderNumber, Price, OrderDateTime, OrderStateId, CreatorUserId, ModifierUserId, OrderStateHistories!, Quantity, UserTotalScore, Prize, FirstName, LastName, OrderDetails);
            return order;
        }
    }

}