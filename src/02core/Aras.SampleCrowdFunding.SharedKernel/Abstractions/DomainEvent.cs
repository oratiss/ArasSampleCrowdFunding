namespace Aras.SampleCrowdFunding.SharedKernel.Abstractions;

    public class DomainEvent
    {
        public long Id { get; set; }
        public long EntityTypeId { get; set; }
        public long EntityId { get; set; }
        public string Data { get; set; } = null!;
        public List<string> Subscribers { get; set; }

        public DomainEvent(List<string> subscribers)
        {
            Subscribers = subscribers;
        }
    }

