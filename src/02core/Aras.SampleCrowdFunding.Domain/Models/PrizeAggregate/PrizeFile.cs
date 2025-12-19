using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate
{
    public class  PrizeFile :  ValueObject
    {
        public long PrizeId { get; private set; }
        public string FileName { get; private set; } = null!;
        public bool IsCover { get; private set; }
        public long? CreatorUserId { get; private set; }

        public PrizeFile(long prizeId, string fileName, bool isCover)
        {
            PrizeId = prizeId;
            FileName = fileName;
            IsCover = isCover;
        }
    }
}
