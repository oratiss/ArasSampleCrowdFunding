namespace Aras.SampleCrowdFunding.UtilityService.RpcResponseStates
{
    public enum RpcServiceStatus
    {
        Success = 200,
        RequestIsNotValid = 400,
        Unauthorized = 401,
        NotFound = 403,
        InternalError = 500
    }
}
