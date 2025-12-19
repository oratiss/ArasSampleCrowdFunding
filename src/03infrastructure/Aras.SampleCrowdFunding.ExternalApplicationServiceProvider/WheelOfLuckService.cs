using Aras.SampleCrowdFunding.ApplicationContract;

namespace Aras.SampleCrowdFunding.ExternalApplicationServiceProvider
{
    //public class WheelOfLuckService : IWheelOfLuckService
    //{
    //    public long? SelectRandomPRizeWithProbabilty(List<Prize> prizes)
    //    {
    //        NormalizedChanceProvider normalizedChanceProvider = new(prizes);
    //        normalizedChanceProvider.NormalizeChances();

    //        List<KeyValuePair<long, double>> keyValuePairs = new();
    //        prizes.ForEach(prize =>
    //        {
    //            keyValuePairs.Add(new(prize.Id, prize.ChanceOfLuck));
    //        });

    //        WeightedRandomizer weightedRandomizer = new(keyValuePairs);
    //        var selectedPrizeId = weightedRandomizer.GetRandomPrize();
    //        return selectedPrizeId;
    //    }

    //    public class NormalizedChanceProvider
    //    {
    //        private List<Prize> prizes;
    //        private int currentIndex;

    //        public NormalizedChanceProvider(List<Prize> prizes)
    //        {
    //            this.prizes = prizes;
    //            currentIndex = 0;
    //        }

    //        public void NormalizeChances()
    //        {
    //            double totalChances = prizes.Count > 0 ? prizes.Sum(prize => prize.ChanceOfLuck) : 0;

    //            if (totalChances > 0)
    //            {
    //                // Normalize each individual chance
    //                foreach (Prize prize in prizes)
    //                {
    //                    double normalizedChance = (prize.ChanceOfLuck * 100.0) / totalChances;
    //                    prize.ChanceOfLuck = (int)Math.Round(normalizedChance);
    //                }

    //                // Adjust the chances to make sure they sum up to 100%
    //                double adjustedTotalChances = prizes.Sum(prize => prize.ChanceOfLuck);

    //                // If the adjustment is necessary, distribute it among the prizes
    //                if (adjustedTotalChances != 100)
    //                {
    //                    int adjustment = 100 - Convert.ToInt32(adjustedTotalChances);

    //                    // Distribute the adjustment among the prizes with the highest chances
    //                    var prizesWithHighestChances = prizes.OrderByDescending(p => p.ChanceOfLuck).Take(adjustment);

    //                    foreach (Prize prize in prizesWithHighestChances)
    //                    {
    //                        prize.ChanceOfLuck++;
    //                    }
    //                }
    //            }
    //        }

    //    }


    //    public class WeightedRandomizer
    //    {
    //        private readonly Random random = new Random();
    //        private readonly List<KeyValuePair<long, double>> prizes;
    //        private double totalProbability;

    //        public WeightedRandomizer(List<KeyValuePair<long, double>> prizes)
    //        {
    //            this.prizes = prizes;
    //            totalProbability = prizes.Sum(p => p.Value);
    //        }

    //        public long? GetRandomPrize()
    //        {
    //            double randomValue = random.NextDouble() * totalProbability;
    //            double accumulatedProbability = 0;

    //            foreach (var prize in prizes)
    //            {
    //                accumulatedProbability += prize.Value;
    //                if (randomValue <= accumulatedProbability)
    //                {
    //                    return prize.Key;
    //                }
    //            }

    //            // Should not reach here if probabilities are correct
    //            return null;
    //        }
    //    }
    //}
}
