namespace Aras.SampleCrowdFunding.Application.Models.Abstractions
{
    public class QueryResponse<T> where T : class?
    {
        public T? ApplicationQueryResponse { get; set; }
        public List<ApplicationError> ApplicationErrors { get; set; } = new();
        public QueryMetaData? MetaData { get; set; }
    }

    public class QueryMetaData
    {
        public long TotalCount { get; set; }
    }
}
