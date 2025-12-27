using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.UserRoles.CommandAndQueryResponses;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.UserRoles.CommandsAndQueries
{
    public class AddUserRoleCommand : IApplicationRequest, IRequest<AddUserRoleCommandResponse?>
    {
        public long CreatorUserId { get; set; }
        public long? ModifierUserId { get; set; }
    }
}
