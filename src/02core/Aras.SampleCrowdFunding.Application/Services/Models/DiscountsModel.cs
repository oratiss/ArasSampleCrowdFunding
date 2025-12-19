namespace Aras.SampleCrowdFunding.Application.Services.Models
{
    public class DiscountsModel
    {
        public List<DiscountModel> Discounts { get; set; }
        public DiscountsModel()
        {
            Discounts = new List<DiscountModel>();
        }
    }
    public class DiscountModel
    {
        public long Id { get; set; }
        public long? PrizeId { get; set; }
        public string? DiscountCode { get; set; }
        public bool IsSold { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
