namespace Aras.SampleCrowdFunding.SharedKernel.Abstractions;

    public class AggregateRoot : AggregateRoot<int>
    {
    }

    public class AggregateRoot<TKey> : StronglyIdentifiableDomainType<TKey> where TKey : struct
    {
        public List<DomainEvent>? DomainEvents { get; set; }
    }

