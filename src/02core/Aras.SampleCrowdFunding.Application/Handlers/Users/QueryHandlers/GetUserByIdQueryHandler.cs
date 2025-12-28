using Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandsAndQueries;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Users;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aras.SampleCrowdFunding.Application.Handlers.Users.QueryHandlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponse?>
    {
        private readonly IServiceScope _serviceScope;
        private readonly IReadableUserRepository _readableUserRepository;

        public GetUserByIdQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceScope = serviceProvider.CreateScope();
            _readableUserRepository = _serviceScope.ServiceProvider.GetRequiredService<IReadableUserRepository>();
        }

        public async Task<GetUserByIdQueryResponse?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            GetUserByIdQueryResponse? response;

            var user = await _readableUserRepository.GetByIdAsync(request.UserId);

            if (user is null)
            {
                response = null;
            }
            else
            {
                response = user.Adapt<GetUserByIdQueryResponse>();
                _serviceScope.Dispose();
            }

            return response;
        }
    }
}
