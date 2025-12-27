using Aras.SampleCrowdFunding.Application.Models.Users.CommandAndQueryResponses;
using Aras.SampleCrowdFunding.Application.Models.Users.CommandsAndQueries;
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
        #region User
        public override async Task<AddUserResponseRpc> AddUserRpc(AddUserRequestRpc request, ServerCallContext context)
        {
            AddUserResponseRpc responseRpc = new() { ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError };

            var command = request.Adapt<AddUserCommand>();
            var commandResponse = await mediator.Send(command);
            if (commandResponse.ApplicationCommandResponse is null)
            {
                responseRpc.Errors.Add("order Not found.");
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.NotFound;
            }
            else
            {
                responseRpc.Result = commandResponse.ApplicationCommandResponse.Adapt<UserResultRpc>();
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.Success;
            }
            return responseRpc;
        }

        public override async Task<GetUserByIdResponseRpc> GetUserByIdRpc(GetUserByIdRequestRpc request, ServerCallContext context)
        {
            GetUserByIdResponseRpc? responseRpc = new() { ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError };

            var requestDto = request.Adapt<GetUserByIdQuery>();
            var queryResponse = await mediator.Send(requestDto);

            if (queryResponse is null)
            {
                responseRpc.Errors.Add("User(s) with given Id Not found.");
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.NotFound;
            }
            else
            {
                var result = queryResponse.Adapt<UserResultRpc>();
                responseRpc.Result = result;
                responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.Success;
            }

            return responseRpc;
        }

        //public override async Task<GetCategoriesResponseRpc> GetCategoriesRpc(GetCategoriesRequestRpc request, ServerCallContext context)
        //{
        //    GetCategoriesResponseRpc? responseRpc = new() { ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError };

        //    var query = request.Adapt<GetCategoriesQuery>();
        //    var queryResponse = await mediator.Send(query);
        //    if (queryResponse is null)
        //    {
        //        responseRpc.Errors.Add("Query has faced with Internal Error.");
        //        responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.InternalServiceError;
        //    }
        //    if (queryResponse!.MetaData!.TotalCount == 0)
        //    {
        //        responseRpc.Errors.Add("category(s) with given mobile number Not found.");
        //        responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.NotFound;
        //    }
        //    else
        //    {
        //        responseRpc.Result.AddRange(queryResponse.ApplicationQueryResponse!.Categories.Select(x => new CategoryResultRpc
        //        {
        //            Id = x.Id,
        //            Name = x.Name,
        //            CreatorUserId = x.CreatorUserId,
        //            ModifierUserId = x.ModifierUserId,
        //            ParentId = x.ParentId,
        //        }).ToList());

        //        responseRpc.MetaData = new ResponseMetaDataRpc() { TotalCount = queryResponse.MetaData!.TotalCount };
        //        responseRpc.ResponseStatus = (int)GrpcResponseStatusEnumeration.Success;
        //    }

        //    return responseRpc;
        //}





        #endregion

    }
}
