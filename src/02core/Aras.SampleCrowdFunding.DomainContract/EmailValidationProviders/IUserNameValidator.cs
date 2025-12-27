namespace Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;

public interface IUserNameValidator
{
    public bool IsUnique(string userName);
}