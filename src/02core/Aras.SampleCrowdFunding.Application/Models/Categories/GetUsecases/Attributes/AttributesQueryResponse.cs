namespace Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Attributes
{
    public class AttributesQueryResponse
    {
        public List<AttributeQueryResponse> Attributes { get; set; }

        public AttributesQueryResponse()
        {
            Attributes = new();
        }
    }

    public class AttributeQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long CategoryId { get; set; }
    }
}
