namespace Aras.SampleCrowdFunding.SharedKernel.Abstractions;

public class DomainEntity<TKey> : StronglyIdentifiableDomainType<TKey> where TKey : struct
{
}

public class DomainEntity : DomainEntity<int>
{
}
