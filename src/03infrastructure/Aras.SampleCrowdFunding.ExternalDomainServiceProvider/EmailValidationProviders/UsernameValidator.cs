using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;
using Atisaz.Core.Infra;

namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.EmailValidationProviders;

public class UsernameValidator(ICrowdFundingUnitOfWork unitOfWork) : IUserNameValidator
{
    public bool IsUnique(string userName)
    {
        var existingUser = unitOfWork.WritableUserRepository.GetFirstOrDefault(x => x.Username.ToLower() == userName.ToLower());
        if (existingUser is null)
            return true;
        return false;
    }
}