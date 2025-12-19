using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.ScoresAggregate
{
    public class DomainScoreTransactionType : DomainEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public List<DomainScoreTransaction>? Scores { get; set; }

        public DomainScoreTransactionType()
        {
            Scores = new();
        }
    }
}
