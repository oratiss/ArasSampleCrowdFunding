using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.AddUsecases
{
    public class AddCategoryCommand : IApplicationRequest, IRequest<AddCategoryCommandResponse>
    {
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
        //public List<AddAttributeCommand>? Attributes { get; set; }
        public long CreatorUserId { get; set; }
        public long? ModifierUserId { get; set; }
    }
}
