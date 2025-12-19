namespace Aras.SampleCrowdFunding.SharedKernel.Abstractions;

public class IntegrationEvent
{
    public long Id { get; set; }
    public long EntityTypeId { get; set; }
    public long EntityId { get; set; }
    public string Data { get; set; } = null!;
    public bool IsSent { get; set; }
    public bool? IsAckReceived { get; set; }
    public bool IsCallBackRequired { get; set; }
}