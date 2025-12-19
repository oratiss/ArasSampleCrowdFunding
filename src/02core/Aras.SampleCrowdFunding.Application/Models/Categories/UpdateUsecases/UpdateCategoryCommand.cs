using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.UpdateUsecases
{
    public class UpdateCategoryCommand : ApplicationCommand, IRequest<UpdateCategoryCommandResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
        public List<UpdateAttributeCommand>? Attributes { get; set; }
    }
}
