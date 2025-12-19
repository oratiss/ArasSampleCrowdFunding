namespace Aras.SampleCrowdFunding.Application.Models.Abstractions;

public class ApplicationError
{
    public string Message { get; set; } = null!;
    public int Code { get; set; }
}