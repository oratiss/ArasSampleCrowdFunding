namespace Aras.SampleCrowdFunding.Application.Models.Abstractions
{
    public class ApplicationQuery : IApplicationRequest
    {
        public long CreatorUserId { get; set; }
        public long? ModifierUserId { get; set; }
    }
}
