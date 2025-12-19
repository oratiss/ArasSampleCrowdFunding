using Aras.SampleCrowdFunding.Application.Services.Models;

namespace Aras.SampleCrowdFunding.Application.Services
{
    public interface IDiscountImporterToDbService
    {
        Task<bool> SaveDiscountWithExcel(DiscountsModel model);
    }
}
