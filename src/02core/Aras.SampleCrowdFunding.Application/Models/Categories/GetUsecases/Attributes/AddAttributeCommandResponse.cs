namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes
{
    public class AddAttributeCommandResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
