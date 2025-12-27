namespace Aras.SampleCrowdFunding.Application.Models.Abstractions;

public class ApplicationError
{
    public int Code { get; set; }
    public string Message { get; set; } = null!;

    public ApplicationError(int code, string message)
    {
        Code = code;
        Message = message;
    }
}