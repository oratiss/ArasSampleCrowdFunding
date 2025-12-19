namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories
{
    public class UpdateCategoryCommandResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
    }
}
