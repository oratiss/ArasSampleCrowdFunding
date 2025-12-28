using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Users;
using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Users;
using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandsAndQueries;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Users;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Domain.Models.Aggregates.UserDomainServices.Users;
using Aras.SampleCrowdFunding.DomainContract.EmailValidationProviders;
using Aras.SampleCrowdFunding.SharedKernel.DomainExceptions;
using Aras.SampleCrowdFunding.UtilityService.CryptogrphyTools;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aras.SampleCrowdFunding.Application.Handlers.Users.CommandHandlers
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, CommandResponse<AddUserCommandResponse?>>
    {
        private readonly ICrowdFundingUnitOfWork _crowdFundingUnitOfWork;
        private readonly IUserNameValidator _usernameValidator;
        private readonly IEmailValidator _emailValidator;
        private readonly IMobileValidator _mobileValidator;
        private readonly IServiceScope _serviceScope;
        private readonly IReadableUserRepository _readableUserRepository;

        public AddUserCommandHandler(ICrowdFundingUnitOfWork crowdFundingUnitOfWork,
            IUserNameValidator usernameValidator,
            IEmailValidator emailValidator,
            IMobileValidator mobileValidator,
            IServiceProvider serviceProvider)
        {
            _crowdFundingUnitOfWork = crowdFundingUnitOfWork;
            _usernameValidator = usernameValidator;
            _emailValidator = emailValidator;
            _mobileValidator = mobileValidator;
            _serviceScope = serviceProvider.CreateScope();
            _readableUserRepository = _serviceScope.ServiceProvider.GetRequiredService<IReadableUserRepository>();
        }

        public async Task<CommandResponse<AddUserCommandResponse?>> Handle(AddUserCommand command, CancellationToken cancellationToken)
        {
            CommandResponse<AddUserCommandResponse?> response = new ();
            try
            {
                //check business rules with domain
                var domainUser = (new DomainUserBuilder(_usernameValidator, _emailValidator, _mobileValidator, command.UserRoles.Adapt<List<DomainUserRole>?>())
                        with { Username = command.Username }
                        with { FirstName = command.FirstName }
                        with { LastName = command.LastName }
                        with { Email = command.Email }
                        with { MobileNumber = command.MobileNumber })
                    .Build();

                //create write entity and save it
                var writableUser = domainUser.Adapt<WritableUser>();
                (writableUser.HashedPassword, writableUser.RandomSalt) = StringHashProvider.HashPassword(command.Password);
                //Todo: write current creator Id and ModifierId from token or Request.
                writableUser.CreateDate = DateTime.UtcNow;
                writableUser.ModifiedDate = DateTime.UtcNow;

                await _crowdFundingUnitOfWork.BeginTransactionAsync();
                await _crowdFundingUnitOfWork.WritableUserRepository.AddAsync(writableUser);
                await _crowdFundingUnitOfWork.SaveChangesAsync();
                writableUser.CreatorUserId = writableUser.Id;
                writableUser.ModifierUserId = writableUser.Id;
                _crowdFundingUnitOfWork.WritableUserRepository.Edit(writableUser);
                await _crowdFundingUnitOfWork.SaveChangesAsync();
                await _crowdFundingUnitOfWork.CommitTransactionAsync();

                //create read entity and save it
                var readableUser = writableUser.Adapt<ReadableUser>();
                readableUser.Id = writableUser.Id;
                await _readableUserRepository.AddAsync(readableUser);
                _serviceScope.Dispose();

                //make response and return it
                response.ApplicationCommandResponse = readableUser.Adapt<AddUserCommandResponse>();
                return response;

            }
            catch (DomainException e)
            {
                response.ApplicationErrors.Add(new ApplicationError(e.Code, e.Message));
                return response;
            }
        }
    }
}
