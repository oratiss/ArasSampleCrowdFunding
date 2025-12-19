using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Models.RayanContracts;

namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Abstractions
{
    public interface IRayanContractsService
    {
        Task<RayanContractsResult>? GeRayanUserContractsAsync(string nationalCode);
    }
}
