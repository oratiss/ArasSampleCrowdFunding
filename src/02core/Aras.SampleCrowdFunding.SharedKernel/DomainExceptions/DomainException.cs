namespace Aras.SampleCrowdFunding.SharedKernel.DomainExceptions
{
    public class DomainException : Exception
    {
        public short Code { get; set; }

        public DomainException(short code, string message) : base(message)
        {
            Code = code;
        }
    }
}
