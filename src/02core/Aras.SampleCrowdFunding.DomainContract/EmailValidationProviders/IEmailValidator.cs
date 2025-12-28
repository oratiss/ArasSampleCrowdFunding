namespace Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders
{
    public interface IEmailValidator
    {
        public bool IsValid(string email);
    }
}
