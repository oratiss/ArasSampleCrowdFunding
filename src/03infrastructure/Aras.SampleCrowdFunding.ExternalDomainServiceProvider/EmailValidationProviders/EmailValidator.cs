using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;
using System.Text.RegularExpressions;

namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.EmailValidationProviders
{
    public class EmailValidator : IEmailValidator
    {
        public bool IsValid(string email)
        {
            return Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase
            );
        }
    }
}
