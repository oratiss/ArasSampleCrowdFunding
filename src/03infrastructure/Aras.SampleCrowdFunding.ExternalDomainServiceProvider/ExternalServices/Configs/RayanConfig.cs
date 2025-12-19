namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Configs
{
    public class RayanConfig
    {
        public string BaseAuthorizeUrl { get; set; } = null!;
        public string ApplicationKey { get; set; } = null!;
        public string AccessTokenHeaderKey { get; set; } = null!;
        public string AccessTokenCacheKey { get; set; } = null!;
        public string BaseUrl { get; set; } = null!;
        public string CustomersPath { get; set; } = null!;
        public string DsCode { get; set; } = null!;
        public string? DbsAccountNumber { get; set; } = null!;
        public string? CBranchId { get; set; } = null!;
        public int DefaultSize { get; set; }
        public int? IsPortfo { get; set; }
        public string Password { get; set; } = null!;
        public string Username { get; set; } = null!;
    }
}
