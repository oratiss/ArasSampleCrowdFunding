using Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Users.CommandsAndQueries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResponse?>
    {
        public int Id { get; set; }
    }
}
