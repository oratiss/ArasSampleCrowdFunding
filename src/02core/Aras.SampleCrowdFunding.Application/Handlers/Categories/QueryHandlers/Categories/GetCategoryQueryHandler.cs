using Aras.SampleCrowdFunding.Application.Models.Abstractions;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Categories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aras.SampleCrowdFunding.Application.Handlers.Categories.QueryHandlers.Categories
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoriesQuery, QueryResponse<CategoriesQueryResponse?>>
    {
        private readonly IServiceScope _serviceScope;
        private readonly IReadableCategoryRepository _readableCategoryRepository;

        public GetCategoryQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceScope = serviceProvider.CreateScope();
            _readableCategoryRepository = _serviceScope.ServiceProvider.GetRequiredService<IReadableCategoryRepository>();
        }

        public async Task<QueryResponse<CategoriesQueryResponse?>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            QueryResponse<CategoriesQueryResponse?> queryResponse = new() { ApplicationQueryResponse = new() };

            var (categories, totalCount) = await _readableCategoryRepository.GetPagedAsync(x => x.Id > -1, request.PageSize, request.PageIndex, request.OrderBy ?? "Id", request.SortOrder is not null ? (Atisaz.Core.Infra.SortOrder)request.SortOrder : Atisaz.Core.Infra.SortOrder.Asc);

            if (totalCount > 0)
            {
                queryResponse!.ApplicationQueryResponse.Categories = categories!.Select(x => new CategoryQueryResponse
                {
                    Id = x.Id,
                    Name = x.Name,
                    ParentId = x.ParentId,
                }).ToList();
            }
            queryResponse.MetaData = new QueryMetaData() { TotalCount = totalCount };
            _serviceScope.Dispose();
            return queryResponse;
        }
    }
}
