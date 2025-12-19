using Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Providers;
using Atisaz.Core.CreationalTools;

namespace Aras.SampleCrowdFunding.Domain.Models.PrizeAggregate.Builders
{
    public class PrizeFileBuilder : ReflectionBuilder<PrizeFile, PrizeFileBuilder>
    {
        private readonly PrizeFileBuilder _builderInstance;

        public string FileName = PrizeFileConstantsProvider.FileName;
        public long PrizeId = PrizeFileConstantsProvider.PrizeId;
        public bool IsCover = PrizeFileConstantsProvider.IsCover;


        public PrizeFileBuilder()
        {
            _builderInstance = this;
        }

        public override PrizeFile Build()
        {
            var prizeFile = new PrizeFile(PrizeId, FileName, IsCover);
            return prizeFile;
        }
    }
}
