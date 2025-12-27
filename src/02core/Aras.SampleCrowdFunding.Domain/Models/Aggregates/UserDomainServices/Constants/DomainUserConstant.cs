namespace Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Constants
{
    public class DomainUserConstant
    {
        public const short UsernameCannotBeNullEmptyOrWhiteSpaceCode = 1;
        public const string UsernameCannotBeNullEmptyOrWhiteSpace = "Username Cannot Be Null, Empty, Or WhiteSpace!";

        public const short UsernameCannotBeLessThan3OrMoreThan50CharsCode = 2;
        public const string UsernameCannotBeLessThan3OrMoreThan50Chars = "Username Cannot Be Less Than 3O Or More Than 50 Chars!";
        
        public const short FirstNameCannotBeNullEmptyOrWhiteSpaceCode = 3;
        public const string FirstNameCannotBeNullEmptyOrWhiteSpace = "FirstName Cannot Be Null, Empty, Or WhiteSpace!";

        public const short FirstNameCannotBeLessThan3OrMoreThan50CharsCode = 4;
        public const string FirstNameCannotBeLessThan3OrMoreThan50Chars = "FirstName Cannot Be Less Than 3O Or More Than 50 Chars!";
        
        public const short LastNameCannotBeNullEmptyOrWhiteSpaceCode = 5;
        public const string LastNameCannotBeNullEmptyOrWhiteSpace = "LastName Cannot Be Null, Empty, Or WhiteSpace!";

        public const short LastNameCannotBeLessThan3OrMoreThan50CharsCode = 6;
        public const string LastNameCannotBeLessThan3OrMoreThan50Chars = "LastName Cannot Be Less Than 3O Or More Than 50 Chars!";

        public const short EmailFormatIsNotValidCode = 7;
        public const string EmailFormatIsNotValid = "Email format is not valid!";

        public const short  MobileNumberFormatIsNotValidCode = 8;
        public const string MobileNumberFormatIsNotValid = "Mobile Number format is not valid!";

        public const short UsernameIsNotUniqueCode = 9;
        public const string UsernameIsNotUnique = "Username is not unqiue!";
    }
}
