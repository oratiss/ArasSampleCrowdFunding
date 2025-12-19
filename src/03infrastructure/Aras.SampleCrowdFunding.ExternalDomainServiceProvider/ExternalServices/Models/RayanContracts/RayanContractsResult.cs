namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Models.RayanContracts
{
    public class RayanContractsResult
    {
        public List<RayanContract>? Result { get; set; }
        public short? PageSize { get; set; }
        public short? PageNumber { get; set; }
        public short? Offset { get; set; }
        public int? Total { get; set; }
    }

    public class RayanContract
    {
        public long? EContractId { get; set; }
        public string? CustomerFullName { get; set; }
        public string? NationalCode { get; set; }
        public short IsPortfo { get; set; }
        public string? DbsAccountNumber { get; set; }
        public string? ContractNum { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? ContractType { get; set; }
        public string? Comments { get; set; }
        public Byte? ContractTypeId { get; set; }
        public string? DlNumber { get; set; }
        
    }
}
