using System.ComponentModel.DataAnnotations;

namespace Aras.SampleCrowdFunding.SharedKernel.Enumerations
{
    public enum OrderProcessingTypeId
    {
        [Display(Name = "نقدی")]
        Cachout = 1,

        [Display(Name = "اعتباری")]
        Credit = 2,

        [Display(Name = "کد تخفیف ساده")]
        SimpleDiscountOrder = 3,

        [Display(Name = "کد تخفیف پیچیده")]
        ComplexDiscountOrder = 4,
    }
}
