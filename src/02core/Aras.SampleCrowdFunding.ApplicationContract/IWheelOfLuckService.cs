namespace Aras.SampleCrowdFunding.ApplicationContract
{
    public interface IWheelOfLuckService
    {
        long? SelectRandomPRizeWithProbabilty(List<Prize> prizes);
    }


    public class Prize
    {
        public long Id { get; set; }
        public double ChanceOfLuck { get; set; }
    }
}
