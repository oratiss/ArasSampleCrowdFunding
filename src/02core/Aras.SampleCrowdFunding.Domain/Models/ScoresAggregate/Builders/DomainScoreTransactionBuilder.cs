using Aras.SampleCrowdFunding.Domain.Models.ScoresAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.ScoresAggregate.Builders
{
    public class DomainScoreTransactionBuilder : ReflectionBuilder<DomainScoreTransaction, DomainScoreTransactionBuilder>
    {
        private readonly DomainScoreTransactionBuilder _builderInstance;

        public long? SejelUserId = ScoreTransactionConstantProvider.SejelUserId;
        public long ScoreTransactionTypeId = ScoreTransactionConstantProvider.ScoreTransactionTypeId;
        public long Score = ScoreTransactionConstantProvider.Score;
        public int CustomerId = ScoreTransactionConstantProvider.CustomerId;
        public string? NationalCode = ScoreTransactionConstantProvider.NationalCode;
        public string ExtraData = ScoreTransactionConstantProvider.ExtraData;
        public bool ScoreDirection = ScoreTransactionConstantProvider.ScoreDirection;
        public DateTime CalculationDate = ScoreTransactionConstantProvider.CalculationDate;
        //public string TransactionDate = ScoreTransactionConstantProvider.TransactionDate;

        public DomainScoreTransactionBuilder()
        {
            _builderInstance = this;
        }

        public override DomainScoreTransaction Build()
        {
            var scoreTransaction = new DomainScoreTransaction(SejelUserId, CustomerId, ScoreTransactionTypeId, ScoreDirection, NationalCode, ExtraData, Score, CalculationDate);
            return scoreTransaction;
        }
    }
}
