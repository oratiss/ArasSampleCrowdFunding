using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Categories;
using Aras.SampleCrowdFunding.Application.Models.Categories.DeleteUsecases;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Builders;
using Mapster;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Handlers.Categories.CommandHandlers.Categories
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse?>
    {
        private readonly ICustomerClubUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(ICustomerClubUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCategoryCommandResponse?> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                DeleteCategoryCommandResponse respopnse = new();

                var category = await _unitOfWork.WritableCategoryRepository.GetByIdAsync(request.Id);

                var domainCategory = new DomainCategoryBuilder(/*null*/)
                  .With(x => x.Id, 0)
                  .With(x => x.CreatorUserId, request.CreatorUserId)
                  .With(x => x.ModifierUserId, request.ModifierUserId)
                  .With(x => x.IsDeleted, true)
                  .Build();

                category.IsDeleted = true;

                await _unitOfWork.BeginTransactionAsync();

                _unitOfWork.WritableCategoryRepository.Edit(category);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var readableAttribute = domainCategory.Adapt<ReadableCategory>();
                readableAttribute.Id = category.Id;

                respopnse = category.Adapt<DeleteCategoryCommandResponse>();
                return respopnse;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
