namespace Aras.SampleCrowdFunding.SharedKernel.Providers
{
    public class OrderStateConstantProvider
    {
        public const string? OrderStateType = "someOrderStateType";
        public static DateTime CreateDate = DateTime.Parse("2023-10-11 18:20:40.501282 +00:00");
        public const long CreatorUserId = -1;
        public static DateTime? ModifiedDate = DateTime.Parse("2023-10-11 18:20:40.501282 +00:00");
        public const long ModifierUserId = -1;
    }
}
