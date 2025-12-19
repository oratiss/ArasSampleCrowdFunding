using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate;
//using Aras.SampleCrowdFunding.DomainContract.CreditValidationProviders;
using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;

namespace Aras.SampleCrowdFunding.Domain.Models.OrderAggregate
{
    public class DomainOrder : AggregateRoot<long>
    {
        public long PrizeId { get; private set; }
        public long SejelUserId { get; private set; }
        public string? OrderNumber { get; private set; }
        public long Price { get; private set; }
        public DateTime OrderDateTime { get; private set; }
        public long OrderStateId { get; private set; }
        public long CreatorUserId { get; private set; }
        public long? ModifierUserId { get; private set; }
        public int Quantity { get; private set; }
        public long? UserTotalScore { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? OrderDetails { get; set; }


        public DomainPrize Prize { get; private set; }
        public List<DomainOrderStateHistory> Histories { get; private set; }

        public DomainOrder(/*ICreditContractValidator creditContractValidator,*/ long id, long prizeId, long sejelUserId, string? orderNumber, long price,  DateTime orderDateTime, long orderStateId, long creatorUserId, long? modifierUserId, List<DomainOrderStateHistory> histories, int quantity, long? userTotalScore,  DomainPrize prize, string? firstName, string? lastName, string? orderDetails)
        {
            if (prize.Quantity < quantity) throw new DomainException(1001, "Quantity is out of Stock");
            if (prize.Quantity == 0) throw new DomainException(1002, "Quantity is soldout");
            if (userTotalScore < price) throw new DomainException(1003, "Score is Lower Than The Price");

            //var isUserEligibleToPlaceOrderOnCreditPrizes = creditContractValidator.CheckUserHaveValidCreditContractAsync(prizeId, sejelUserId).Result;
            //if (!isUserEligibleToPlaceOrderOnCreditPrizes)
            //{
            //    throw new DomainException(403, "This User is forbidden to order credit prizes as they have not credit contract!");
            //}

            Id = id;
            PrizeId = prizeId;
            SejelUserId = sejelUserId;
            OrderNumber = orderNumber;
            Price = price;
            Quantity = quantity;
            OrderDateTime = orderDateTime;
            OrderStateId = orderStateId;
            CreatorUserId = creatorUserId;
            ModifierUserId = modifierUserId;
            Histories = histories;
            FirstName = firstName;
            LastName = lastName;
            OrderDetails = orderDetails;
        }
    }
}
