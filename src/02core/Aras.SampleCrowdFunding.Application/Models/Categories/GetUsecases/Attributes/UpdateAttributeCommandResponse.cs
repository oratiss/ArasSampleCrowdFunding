namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes
{
    public class UpdateAttributeCommandResponse
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; } = null!;
    }
}
