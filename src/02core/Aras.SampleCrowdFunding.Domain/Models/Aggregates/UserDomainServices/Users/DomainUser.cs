using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;
using Aras.SampleCrowdFunding.SharedKernel.Abstractions;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;
using static Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Constants.DomainUserConstant;

namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Users
{
    public class DomainUser : AggregateRoot<int>
    {
        public string Username { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string? Email { get; private set; }
        public string? MobileNumber { get; private set; }
        public IList<DomainUserRole>? DomainUserRoles { get; private set; }


        public DomainUser(IEmailValidator emailValidator,
            IMobileValidator mobileValidator,
            IUserNameValidator userNameValidator,
            int id,
             string username,
             string firstName,
             string lastName,
             string? email,
             string? mobileNumber,
             List<DomainUserRole>? domainUserRoles = null)
        {
            //business Rules
            if (string.IsNullOrWhiteSpace(username))
                throw new DomainException(UsernameCannotBeNullEmptyOrWhiteSpaceCode, UsernameCannotBeNullEmptyOrWhiteSpace);
            if (username.Length < 3 || username.Length > 50)
                throw new DomainException(UsernameCannotBeLessThan3OrMoreThan50CharsCode, UsernameCannotBeLessThan3OrMoreThan50Chars);
            if (string.IsNullOrWhiteSpace(firstName))
                throw new DomainException(FirstNameCannotBeNullEmptyOrWhiteSpaceCode, FirstNameCannotBeNullEmptyOrWhiteSpace);
            if (username.Length < 3 || firstName.Length > 50)
                throw new DomainException(FirstNameCannotBeLessThan3OrMoreThan50CharsCode, FirstNameCannotBeLessThan3OrMoreThan50Chars);
            if (string.IsNullOrWhiteSpace(lastName))
                throw new DomainException(LastNameCannotBeNullEmptyOrWhiteSpaceCode, LastNameCannotBeNullEmptyOrWhiteSpace);
            if (username.Length < 3 || lastName.Length > 50)
                throw new DomainException(LastNameCannotBeLessThan3OrMoreThan50CharsCode, LastNameCannotBeLessThan3OrMoreThan50Chars);

            if (!string.IsNullOrWhiteSpace(email) && !emailValidator.IsValid(email))
                throw new DomainException(EmailFormatIsNotValidCode, EmailFormatIsNotValid);

            if (!string.IsNullOrWhiteSpace(mobileNumber) && !mobileValidator.IsValid(mobileNumber))
                throw new DomainException(MobileNumberFormatIsNotValidCode, MobileNumberFormatIsNotValid);

            if (!userNameValidator.IsUnique(username))
                throw new DomainException(UsernameIsNotUniqueCode, UsernameIsNotUnique);

            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            MobileNumber = mobileNumber;
            DomainUserRoles = (domainUserRoles is not null && domainUserRoles.Count < 1 ) ? [new DomainUserRole(1, id, 1)] : domainUserRoles;
        }
    }
}
