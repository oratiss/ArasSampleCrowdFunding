using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFunding.Application.Repositories.IReadableRepositories.Categories;
using Mapster;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Aras.SampleCrowdFunding.Application.Handlers.Categories.QueryHandlers.Categories
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryQueryResponse?>
    {
        private readonly IServiceScope _serviceScope;
        private readonly IReadableCategoryRepository _readableCategoryRepository;

        public GetCategoryByIdQueryHandler(IServiceProvider serviceProvider)
        {
            _serviceScope = serviceProvider.CreateScope();
            _readableCategoryRepository = _serviceScope.ServiceProvider.GetRequiredService<IReadableCategoryRepository>();
        }

        public async Task<CategoryQueryResponse?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                CategoryQueryResponse getCategory = new();

                var category = await _readableCategoryRepository.GetByIdAsync(request.CategoryId);

                if (category is null)
                    getCategory = null;

                getCategory = category.Adapt<CategoryQueryResponse>();

                _serviceScope.Dispose();
                return getCategory;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
