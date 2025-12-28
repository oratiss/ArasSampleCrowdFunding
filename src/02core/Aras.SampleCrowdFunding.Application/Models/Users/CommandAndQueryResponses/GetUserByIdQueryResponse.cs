using Aras.SampleCrowdFunding.Application.Models.UserRoles.CommandAndQueryResponses;

namespace Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;

public class GetUserByIdQueryResponse
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? MobileNumber { get; set; } = null!;
    public int CreatorUserId { get; set; }
    public int? ModifierUserId { get; set; }
    public IList<AddUserRoleCommandResponse>? UserRoles { get; set; }
}