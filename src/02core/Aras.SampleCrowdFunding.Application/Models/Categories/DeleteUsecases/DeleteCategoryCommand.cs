using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.DeleteUsecases
{
    public class DeleteCategoryCommand : ApplicationCommand, IRequest<DeleteCategoryCommandResponse>
    {
        public long Id { get; set; }
    }
}
