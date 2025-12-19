using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.AddUsecases
{
    public class AddAttributeCommand : IApplicationRequest, IRequest<AddAttributeCommandResponse>
    {
        public string Name { get; set; } = null!;
        public long CategoryId { get; set; }
        public long CreatorUserId { get; set; }
        public long? ModifierUserId { get; set; }
    }
}
