using Aras.SampleCrowdFunding.SharedKernel.Abstractions;

namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Users;

public class DomainUserRole: DomainEntity<long>
{
    public int DomainUserId { get; set; } 
    public int DomainRoleId { get; set; }

    public DomainUserRole(long id, int domainUserId, int domainRoleId)
    {
        Id = id;
        DomainUserId = domainUserId;
        DomainRoleId = domainRoleId;
    }
}