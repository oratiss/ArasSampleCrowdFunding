//using Aras.SampleCrowdFunding.Application.UnitOFWorks;
//using Aras.SampleCrowdFunding.DomainContract.CreditValidationProviders;
//using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Abstractions;
//using Atisaz.Core.Infra;
//using Atisaz.Grpc.Utilities;
//using Atisaz.SejelMicroService.Atisaz.SejelMicroService.GrpcService;
//using Microsoft.Extensions.DependencyInjection;

//namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.CreditValidationProviders
//{
//    public class RayanCreditContractValidator : ICreditContractValidator
//    {
//        private readonly IRayanContractsService _rayanContractsService;
//        private readonly ICustomerClubUnitOfWork _unitOfWork;
//        private readonly Sejel_MainServiceRpc.Sejel_MainServiceRpcClient _sejelMainServiceRpcClient;

//        public RayanCreditContractValidator(IRayanContractsService rayanContractsService,
//            ICustomerClubUnitOfWork unitOfWork, IServiceProvider serviceProvider)
//        {
//            _rayanContractsService = rayanContractsService;
//            _unitOfWork = unitOfWork;
//            var serviceScope = serviceProvider.CreateScope();
//            _sejelMainServiceRpcClient = serviceScope.ServiceProvider
//                .GetRequiredService<Sejel_MainServiceRpc.Sejel_MainServiceRpcClient>();
//        }

//        public async Task<bool> CheckUserHaveValidCreditContractAsync(long prizeId, long sejelUserId)
//        {
//            var prize = await _unitOfWork.WritablePrizeRepository.GetByIdAsync(prizeId);

//            if (prize is null)
//            {
//                throw new Exception("Prize Not Found. So no order can be placed on this price");
//            }

//            if (prize.OrderProcessingTypeId == 1003)
//            {
//                var gRpcResponse = await _sejelMainServiceRpcClient.GetUserByIdRpcAsync(new GetUserByIdRequestRpc()
//                {
//                    Id = sejelUserId
//                });
//                if (gRpcResponse is null) return false;
//                if (gRpcResponse.ResponseStatus != (int)GrpcResponseStatusEnumeration.Success)
//                {
//                    throw new Exception("Sejel Grpc Service returned nothing.");
//                }

//                var rayanContractResult = await _rayanContractsService.GeRayanUserContractsAsync(gRpcResponse.Result.NationalCode)!;

//                // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
//                if (rayanContractResult is null) return false;
//                var todayDate = DateTime.UtcNow;
//                var existingCreditContract = rayanContractResult.Result!.FirstOrDefault(c =>
//                    c.ContractTypeId == 3 && c.EndDate!.ToUtcDateTimeConsideringLeapYear()!.Value >= todayDate);
//                if (existingCreditContract is not null)
//                {
//                    return true;
//                }
//            }
//            else
//            {
//                return true;
//            }

//            return false;

//        }
//    }
//}
