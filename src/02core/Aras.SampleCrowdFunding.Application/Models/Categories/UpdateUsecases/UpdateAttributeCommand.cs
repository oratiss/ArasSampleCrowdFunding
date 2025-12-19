using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.UpdateUsecases
{
    public class UpdateAttributeCommand : ApplicationCommand, IRequest<UpdateAttributeCommandResponse>
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
    }
}
