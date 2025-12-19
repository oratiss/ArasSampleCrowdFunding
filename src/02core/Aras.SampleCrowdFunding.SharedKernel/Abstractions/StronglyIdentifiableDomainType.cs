namespace Aras.SampleCrowdFunding.SharedKernel.Abstractions;

public abstract class StronglyIdentifiableDomainType<TKey> where TKey : struct
{
    public TKey Id { get; init; }
}
