using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;

namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Users
{
    public record DomainUserBuilder
    {
        private readonly IEmailValidator _emailValidator;
        private readonly IUserNameValidator _userNameValidator;
        private readonly IMobileValidator _mobileValidator;
        private readonly DomainUserBuilder _builderInstance;
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public IList<DomainUserRole>? DomainUserRoles { get; set; }

        public DomainUserBuilder(IUserNameValidator userNameValidator
            , IEmailValidator emailValidator
            , IMobileValidator mobileValidator
            , IList<DomainUserRole>? domainUserRoles)
        {
            _builderInstance = this;
           _emailValidator = emailValidator;
           _userNameValidator = userNameValidator;
           _mobileValidator = mobileValidator;
            DomainUserRoles = domainUserRoles;
        }

        public DomainUser Build()
        {
            var domainUser = new DomainUser(_emailValidator, _mobileValidator, _userNameValidator, Id, Username,
                FirstName, LastName, Email, MobileNumber, DomainUserRoles as List<DomainUserRole>);
            return domainUser;
        }
    }
}
