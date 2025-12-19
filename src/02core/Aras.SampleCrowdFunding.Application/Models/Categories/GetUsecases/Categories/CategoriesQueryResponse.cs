using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes;

namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories
{
    public class CategoriesQueryResponse
    {
        public List<CategoryQueryResponse> Categories { get; set; }
        public CategoriesQueryResponse()
        {
            Categories = new();
        }
    }

    public class CategoryQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
        public long CreatorUserId { get; set; }
        public long? ModifierUserId { get; set; }
        //public List<AttributeQueryResponse>? Attributes { get; set; }
        public CategoryQueryResponse()
        {
            //Attributes = new();
        }
    }
}
