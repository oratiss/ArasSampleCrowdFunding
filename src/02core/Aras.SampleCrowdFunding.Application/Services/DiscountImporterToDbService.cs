using Aras.SampleCrowdFunding.Application.Services.Models;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;

namespace Aras.SampleCrowdFunding.Application.Services
{
    public class DiscountImporterToDbService : IDiscountImporterToDbService
    {
        private readonly ICustomerClubUnitOfWork _unitOfWork;
        public DiscountImporterToDbService(ICustomerClubUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> SaveDiscountWithExcel(DiscountsModel model)
        {
            try
            {
                foreach (var discount in model.Discounts)
                {

                }

                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
    

