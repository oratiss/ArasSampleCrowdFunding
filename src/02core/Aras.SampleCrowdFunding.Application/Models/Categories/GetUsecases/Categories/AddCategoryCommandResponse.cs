namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories
{
    public class AddCategoryCommandResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long? ParentId { get; set; }
    }
}
