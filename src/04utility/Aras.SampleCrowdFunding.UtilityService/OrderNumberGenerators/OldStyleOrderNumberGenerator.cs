using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Aras.SampleCrowdFunding.UtilityService.OrderNumberGenerators
{
    public static class OldStyleOrderNumberGenerator
    {
        private static readonly string prefix = "Ord-";
        private static readonly Regex regex = new Regex(@"^" + prefix + @"(\d{7})$");

        public static async Task<string> GenerateOrderNumberAsync()
        {
            var currentDateTimeUtc = DateTimeOffset.UtcNow;
            var milliseconds = currentDateTimeUtc.Millisecond;

            using SHA256 sha256 = SHA256.Create();
            var hashedMilliseconds = sha256.ComputeHash(Encoding.UTF8.GetBytes(milliseconds.ToString()));
            var orderNumber = $"{prefix}{BitConverter.ToString(hashedMilliseconds).Replace("-", "").Substring(0, 7)}";

            // Check if the generated order number already exists
            while (regex.IsMatch(orderNumber))
            {
                // Generate a new order number with a different millisecond value
                currentDateTimeUtc = currentDateTimeUtc.AddMilliseconds(1);
                milliseconds = currentDateTimeUtc.Millisecond;
                hashedMilliseconds = sha256.ComputeHash(Encoding.UTF8.GetBytes(milliseconds.ToString()));
                orderNumber = $"{prefix}{BitConverter.ToString(hashedMilliseconds).Replace("-", "").Substring(0, 7)}";
            }

            return orderNumber;
        }

    }
}
