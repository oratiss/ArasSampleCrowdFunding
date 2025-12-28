using Aras.SampleCrowdFunding.UtilityService.RpcResponseStates;

namespace Aras.SampleCrowdFundingMicroservice.SampleCrowdFunding.GrpcService;

public sealed partial class GetUserByIdRequestRpc : IRequestRpc
{
    public bool IsCancellationRequested { get; set; }
    public bool IsValid(out List<string> errorList)
    {
        errorList = new();
        return true;
    }
}