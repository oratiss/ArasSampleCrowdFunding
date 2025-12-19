using Aras.SampleCrowdFunding.Application.Models.Categories.AddUsecases;
using Aras.SampleCrowdFunding.Application.Models.Categories.GetUsecases.Categories;
using Aras.SampleCrowdFundingMicroservice.SampleCrowdFunding.GrpcService;
using Atisaz.Grpc.Utilities;
using Common;
using Grpc.Core;
using Mapster;
using MediatR;

namespace Aras.SampleCrowdFunding.GrpcService.Services
{
    public class SampleCrowdFundingService(IMediator mediator) : SampleCrowdFundingServiceRpc.SampleCrowdFundingServiceRpcBase
    {
        #region Category
        public override async Task<AddCategoryResponseRpc> AddCategoryRpc(AddCategoryRequestRpc request, ServerCallContext context)
        {
            AddCategoryResponseRpc responseRpc = new() { ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError };

            var command = request.Adapt<AddCategoryCommand>();
            //command.Attributes = request.Attributes.Select(x => x.Adapt<AddAttributeCommand>()).ToList();
            var commandResponse = await mediator.Send(command);
            if (commandResponse is null)
            {
                responseRpc.Errors.Add("order Not found.");
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.NotFound;
            }
            else
            {
                responseRpc.Result = commandResponse.Adapt<CategoryResultRpc>();
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.Success;
            }
            return responseRpc;
        }

        public override async Task<GetCategoriesResponseRpc> GetCategoriesRpc(GetCategoriesRequestRpc request, ServerCallContext context)
        {
            GetCategoriesResponseRpc? responseRpc = new() { ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError };

            var query = request.Adapt<GetCategoriesQuery>();
            var queryResponse = await mediator.Send(query);
            if (queryResponse is null)
            {
                responseRpc.Errors.Add("Query has faced with Internal Error.");
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError;
            }
            if (queryResponse!.MetaData!.TotalCount == 0)
            {
                responseRpc.Errors.Add("category(s) with given mobile number Not found.");
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.NotFound;
            }
            else
            {
                responseRpc.Result.AddRange(queryResponse.ApplicationQueryResponse!.Categories.Select(x => new CategoryResultRpc
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatorUserId = x.CreatorUserId,
                    ModifierUserId = x.ModifierUserId,
                    ParentId = x.ParentId,
                }).ToList());

                responseRpc.MetaData = new ResponseMetaDataRpc() { TotalCount = queryResponse.MetaData!.TotalCount };
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.Success;
            }

            return responseRpc;
        }

        public override async Task<GetCategoryByIdResponseRpc> GetCategoryByIdRpc(GetCategoryByIdRequestRpc request, ServerCallContext context)
        {
            GetCategoryByIdResponseRpc? responseRpc = new() { ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError };

            var requestDto = request.Adapt<GetCategoryByIdQuery>();
            var categoryResponse = await mediator.Send(requestDto);

            if (categoryResponse is null)
            {
                responseRpc.Errors.Add("category(s) with given mobile number Not found.");
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.NotFound;
            }
            else
            {
                var result = categoryResponse.Adapt<CategoryResultRpc>();
                responseRpc.Result = result;
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.Success;
            }

            return responseRpc;
        }



        #endregion

    }
}
