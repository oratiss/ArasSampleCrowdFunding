using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Categories;
using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Categories;
using Aras.SampleCrowdFunding.Application.Models.Categories.AddUsecases;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Categories;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Builders;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aras.SampleCrowdFunding.Application.Handlers.Categories.CommandHandlers.Categories
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryCommandResponse?>
    {
        private readonly ICustomerClubUnitOfWork _unitOfWork;
        private readonly IReadableCategoryRepository _readableCategoryRepository;

        public AddCategoryCommandHandler(ICustomerClubUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
            var serviceScope = serviceProvider.CreateScope();
            _readableCategoryRepository = serviceScope.ServiceProvider.GetRequiredService<IReadableCategoryRepository>();
        }

        public async Task<AddCategoryCommandResponse?> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                AddCategoryCommandResponse? getCategory = new();

                var domainCategory = new DomainCategoryBuilder(/*request.Attributes?.Select(rqst => new DomainAttributeBuilder()
                                                                            .With(da => da.CategoryId, rqst.CategoryId)
                                                                            .With(da => da.Name, rqst.Name)
                                                                            .With(da => da.CreatorUserId, rqst.CreatorUserId)
                                                                            .With(da => da.ModifierUserId, rqst.ModifierUserId))
                                                                            .ToList()*/)
                    .With(x => x.Id, 0)
                    .With(x => x.Name, request.Name)
                    .With(x => x.ParentId, request.ParentId)
                    .With(x => x.CreatorUserId, request.CreatorUserId)
                    .With(x => x.ModifierUserId, request.ModifierUserId)
                    .Build();

                await _unitOfWork.BeginTransactionAsync();

                var writableCategory = domainCategory.Adapt<WritableCategory>();


                await _unitOfWork.WritableCategoryRepository.AddAsync(writableCategory);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var readableCategory = writableCategory.Adapt<ReadableCategory>();

                readableCategory.Id = writableCategory.Id;

              _ = _readableCategoryRepository.AddAsync(readableCategory);

                getCategory = readableCategory.Adapt<AddCategoryCommandResponse>();
                return getCategory;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
