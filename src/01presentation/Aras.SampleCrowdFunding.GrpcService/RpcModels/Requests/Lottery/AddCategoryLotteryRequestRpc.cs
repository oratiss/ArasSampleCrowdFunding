

using Aras.SampleCrowdFunding.UtilityService.RpcResponseStates;

#pragma warning disable IDE0130
namespace Aras.SampleCrowdFundingMicroservice.SampleCrowdFunding.GrpcService
#pragma warning restore IDE0130
{
    public partial class AddCategoryLotteryRequestRpc : IRequestRpc
    {
        public bool IsCancellationRequested { get; set; }
        public bool IsValid(out List<string> errorList)
        {
            errorList = new List<string>();
            return true;
        }
    }
}
