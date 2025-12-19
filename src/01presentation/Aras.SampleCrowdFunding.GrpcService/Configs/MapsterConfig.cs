using Aras.SampleCrowdFundingMicroservice.SampleCrowdFunding.GrpcService;

namespace Atisaz.CustomerClubMicroservice.GrpcService.Configs
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration()
        {
          //  TypeAdapterConfig<AddPrizeRequestRpc, AddPrizeCommand>.NewConfig()
          //      .Map(dest => dest.Quantity, src => (byte)src.Quantity)
          //     /* .Map(dest => dest.Price, src => MapDecimalValueToDecimal(src.Price))*/;

          //  TypeAdapterConfig<GetScoreTransactionsBySejelUserIdRequestRpc, GetScoreTransactionBySejelUserIdQuery>.NewConfig()
          //      .Map(dest => dest.CalculationStartDate, src => src.CalculationStartDate.ToDateTime());

          //  TypeAdapterConfig<GetScoreBySejelUserIdRequestRpc, GetScoreBySejelUserIdQuery>.NewConfig()
          //  .Map(dest => dest.CalculationStartDate, src => src.CalculationStartDate.ToDateTime());

          //  TypeAdapterConfig<GetScoreTransactionsRequestRpc, GetAllScoreTransactionHistoryQuery>.NewConfig()
          //.Map(dest => dest.CalculationStartDate, src => src.CalculationStartDate.ToDateTime());

          //  TypeAdapterConfig<AddOrderRequestRpc, AddOrderCommand>.NewConfig()
          // .Map(dest => dest.CalculationStartDate, src => src.CalculationStartDate.ToDateTime());

          //  TypeAdapterConfig<WheelOfLuckRequestRpc, WheelOfLuckCommand>.NewConfig()
          //      .Map(dest => dest.CalculationStartDate, src => src.CalculationStartDate.ToDateTime());

          //  TypeAdapterConfig<AddLotteryRequestRpc, AddLotteryCommand>.NewConfig()
          //      .Map(dest => dest.CalculationStartDate, src => src.CalculationStartDate.ToDateTime());

          //  TypeAdapterConfig<AddPrizeCommandResponse, PrizeResultRpc>.NewConfig()
          //      .Map(dest => dest.Quantity, src => (int)src.Quantity)
          //     /* .Map(dest => dest.Price, src => MapDecimalToDecimalValue(src.Price))*/;

          //  TypeAdapterConfig.GlobalSettings.Scan(Assembly.GetExecutingAssembly());


          //  TypeAdapterConfig<GetScoreTransactionBySejelUserIdQueryResponse, GetScoreTransactionsBySejelUserIdResultRpc>
          //      .NewConfig()
          //      .Map(dest => dest.TransactionDate, src => src.TransactionDate.HasValue ? Timestamp.FromDateTime(DateTime.SpecifyKind(src.TransactionDate.Value, DateTimeKind.Utc)) : null);

          //  TypeAdapterConfig<GetAllScoreTransactionHistoryQueryResponse, GetScoreTransactionsResultRpc>
          //   .NewConfig()
          //   .Map(dest => dest.TransactionDate, src => src.TransactionDate.HasValue ? Timestamp.FromDateTime(DateTime.SpecifyKind(src.TransactionDate.Value, DateTimeKind.Utc)) : null);


        }

        private static decimal MapDecimalValueToDecimal(DecimalValue grpcDecimal)
        {
            return grpcDecimal.Units + grpcDecimal.Nanos / DecimalValue.GetNanoFactor();
        }

        private static DecimalValue MapDecimalToDecimalValue(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * DecimalValue.GetNanoFactor());
            return new DecimalValue(units, nanos);
        }
    }
}