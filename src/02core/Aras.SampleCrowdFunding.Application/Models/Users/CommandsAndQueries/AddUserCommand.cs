using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.UserRoles.CommandsAndQueries;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Users.CommandsAndQueries
{
    public class AddUserCommand : IApplicationRequest, IRequest<CommandResponse<AddUserCommandResponse?>>
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Email { get; set; }
        public string? MobileNumber { get; set; }
        public IList<AddUserRoleCommand>? UserRoles { get; set; }
        public long CreatorUserId { get; set; }
        public long? ModifierUserId { get; set; }
        public string Password { get; set; } = null!;
    }
}
