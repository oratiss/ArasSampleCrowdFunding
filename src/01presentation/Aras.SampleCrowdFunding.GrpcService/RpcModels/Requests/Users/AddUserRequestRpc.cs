using Atisaz.Grpc.Utilities;
using FluentValidation;

#pragma warning disable IDE0130
namespace Aras.SampleCrowdFundingMicroservice.SampleCrowdFunding.GrpcService
#pragma warning restore IDE0130
{
    public sealed partial class AddUserRequestRpc : IRequestRpc
    {
        public bool IsCancellationRequested { get; set; }
        public bool IsValid(out List<string> errorList)
        {
            errorList = new List<string>();
            var validator = new InlineValidator<AddUserRequestRpc>();
            validator.RuleFor(request => request.Password)
                .NotEmpty()
                .MinimumLength(8)
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches(@"[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]")
                .WithMessage("Password must contain at least one special character.")
                .Must(p => !p.Contains(" "))
                .WithMessage("Password must not contain spaces.");



            var result = validator.Validate(this);
            if (!result.IsValid)
            {
                foreach (string error in result.Errors.Select(x => x.ErrorMessage))
                {
                    errorList.Add(error);
                }

                return false;
            }

            return true;
        }

    }
}
