namespace Aras.SampleCrowdFunding.Application.Models.UserRoles.CommandAndQueryResponses
{
    public class AddUserRoleCommandResponse
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
