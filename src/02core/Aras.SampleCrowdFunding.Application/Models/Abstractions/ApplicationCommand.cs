namespace Aras.SampleCrowdFunding.Application.Models.Abstractions;

public class ApplicationCommand : IApplicationRequest
{
    public long CreatorUserId { get; set; }
    public long? ModifierUserId { get; set; }
}