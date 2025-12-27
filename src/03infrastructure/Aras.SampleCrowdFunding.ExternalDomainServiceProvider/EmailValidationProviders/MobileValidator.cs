using System.Text.RegularExpressions;
using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;

namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.EmailValidationProviders;

public class MobileValidator: IMobileValidator
{
    public bool IsValid(string mobileNumber)
    {
        return Regex.IsMatch(
            mobileNumber,
            @"^(?:\+|00)[1-9]\d{6,14}$"
        );
    }
}