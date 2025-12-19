namespace Aras.SampleCrowdFunding.Application.Models.Abstractions;

public interface IApplicationRequest
{
    public long CreatorUserId { get; set; }
    public long? ModifierUserId { get; set; }
}