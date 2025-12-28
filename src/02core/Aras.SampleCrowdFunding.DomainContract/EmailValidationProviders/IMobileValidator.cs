namespace Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;

public interface IMobileValidator
{
    public bool IsValid(string mobileNumber);
}