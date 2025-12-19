using Aras.SampleCrowdFunding.Application.DataModels.ReadModels.Categories;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFunding.Application.Models.Categories.UpdateUsecases;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Domain.Models.CategoryAggregate.Builders;
using Mapster;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Handlers.Categories.CommandHandlers.Categories
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResponse?>
    {
        private readonly ICustomerClubUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICustomerClubUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCategoryCommandResponse?> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UpdateCategoryCommandResponse? getAttributeDto = new();

                var category = await _unitOfWork.WritableCategoryRepository.GetByIdAsync(request.Id);

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


                category!.ParentId = request.ParentId;
                category.Name = request.Name;

                await _unitOfWork.BeginTransactionAsync();

                _unitOfWork.WritableCategoryRepository.Edit(category);

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitTransactionAsync();

                var readableAttribute = domainCategory.Adapt<ReadableCategory>();
                readableAttribute.Id = category.Id;

                getAttributeDto = category.Adapt<UpdateCategoryCommandResponse>();
                return getAttributeDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
