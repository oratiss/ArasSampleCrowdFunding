namespace Aras.SampleCrowdFunding.Application.Models.Abstractions;

public interface ISortableApplicationRequest
{
    string? OrderBy { get; set; }

    int? SortOrder { get; set; }
}