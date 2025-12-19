using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.ScoresAggregate
{
    public class DomainScoreTransaction : AggregateRoot<long>
    {
        public new long Id { get; set; }
        public long? SejelUserId { get; set; }
        public int CustomerId { get; set; }
        public DomainScoreTransactionType ScoreTransactionType { get; set; } = null!;
        public long ScoreTransactionTypeId { get; set; }
        public bool ScoreDirection { get; set; }
        public string? NationalCode { get; set; }
        public string ExtraData { get; set; } = null!;
        public long Score { get; set; }
        public DateTime CalculationDate { get; set; }
        public DateTime? TransactionDate { get; set; }

        public DomainScoreTransaction(long? sejelUserId, int customerId, long scoreTransactionTypeId, bool scoreDirectio, string? nationalCode, string extraData, long score, DateTime calculationDate)
        {
            SejelUserId = sejelUserId;
            CustomerId = customerId;
            ScoreTransactionTypeId = scoreTransactionTypeId;  
            ScoreDirection = scoreDirectio;
            ExtraData = extraData;
            Score = score;
            CalculationDate = calculationDate;
            NationalCode = nationalCode;
        }
    }
}
