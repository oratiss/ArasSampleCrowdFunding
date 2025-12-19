using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes
{
    public class GetAttributesQuery : ApplicationQuery,  ISortableApplicationRequest, IRequest<QueryResponse<AttributesQueryResponse?>>
    {
        public string? OrderBy { get; set; } = "Id";
        public int? SortOrder { get; set; } = 1;
    }
}
