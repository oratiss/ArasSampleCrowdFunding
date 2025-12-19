namespace Aras.SampleCrowdFunding.Application.Models.Abstractions;

public class CommandResponse<T> where T : class
{
    public T? ApplicationCommandResponse { get; set; }
    public List<ApplicationError> ApplicationErrors { get; set; }

    public CommandResponse()
    {
        ApplicationErrors = new();
    }
}