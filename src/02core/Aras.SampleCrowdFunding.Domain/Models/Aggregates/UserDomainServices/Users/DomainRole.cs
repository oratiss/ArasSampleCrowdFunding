using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;
using static Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Constants.DomainRoleConstant;
namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Users;

public class DomainRole : DomainEntity<int>
{
    public string Name { get; set; }
    public IList<DomainUserRole>? DomainUserRoles { get; set; }

    public DomainRole(string name, List<DomainUserRole> domainUserRoles)
    {
        if (!string.IsNullOrWhiteSpace(Name))
            throw new DomainException(RoleShouldNotBeNullEmptyOrWhiteSpaceCode, RoleShouldNotBeNullEmptyOrWhiteSpace);

        Name = name;
        DomainUserRoles = domainUserRoles;
    }
}