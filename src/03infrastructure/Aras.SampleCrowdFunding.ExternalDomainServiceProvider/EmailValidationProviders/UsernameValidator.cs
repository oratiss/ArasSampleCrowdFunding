using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;

namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.EmailValidationProviders;

public class UsernameValidator : IUserNameValidator
{
    public bool IsUnique(string userName)
    {
        throw new NotImplementedException();
    }
}