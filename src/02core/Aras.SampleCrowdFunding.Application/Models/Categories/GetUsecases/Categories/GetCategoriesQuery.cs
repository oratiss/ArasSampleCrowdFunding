using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories
{
    public class GetCategoriesQuery : ApplicationQuery, IPaginationApplicationRequest, ISortableApplicationRequest, IRequest<QueryResponse<CategoriesQueryResponse?>>
    {
        public int PageSize { get; set; } = 10;
        public int PageIndex { get; set; } = 1;
        public string? OrderBy { get; set; } = "Id";
        public int? SortOrder { get; set; } = 1;
    }
}
