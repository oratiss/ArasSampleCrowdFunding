namespace Aras.SampleCrowdFunding.Application.Models.Abstractions
{
    public interface IPaginationApplicationRequest
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }
    }
}
