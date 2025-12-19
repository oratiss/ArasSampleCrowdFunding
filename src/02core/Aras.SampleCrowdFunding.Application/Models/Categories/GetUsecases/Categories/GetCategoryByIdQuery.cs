using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using MediatR;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories
{
    public class GetCategoryByIdQuery : ApplicationQuery, IRequest<CategoryQueryResponse>
    {
        public long CategoryId { get; set; }
    }
}
