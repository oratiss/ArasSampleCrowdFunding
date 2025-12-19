using System.Text.Encodings.Web;
using System.Text.Json;
using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Abstractions;
using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Configs;
using Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices.Models.RayanContracts;
using Atisaz.Cache.Utilities.Adapters;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Aras.SampleCrowdFunding.ExternalDomainServiceProvider.ExternalServices
{
    public class RayanContractService : IRayanContractsService
    {

        private readonly RayanConfig _rayanConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGlobalRedisCacheService _globalRedisCacheService;
        private readonly string _accessTokenCacheKey;
        private readonly string _accessTokenHeaderKey;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        public RayanContractService(IOptions<RayanConfig> rayanConfig,
        IHttpClientFactory httpClientFactory)
        {
            _rayanConfig = rayanConfig.Value;
            _accessTokenHeaderKey = _rayanConfig.AccessTokenHeaderKey;
            _accessTokenCacheKey = _rayanConfig.AccessTokenCacheKey;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<RayanContractsResult>? GeRayanUserContractsAsync(string nationalCode)
        {
            try
            {
                var queryParams = new Dictionary<string, string?>()
                {
                    {"size","-1"},
                    { "isPortfo", _rayanConfig.IsPortfo.ToString()},
                    { "dsName", "191" },
                    { "nationalCode", nationalCode }
                };
                var url = QueryHelpers.AddQueryString($"{_rayanConfig.BaseUrl}/eContracts", queryParams);
                var accessToken = await GetRayanAccessToken();
                var httpClient = _httpClientFactory.CreateClient();
                httpClient.DefaultRequestHeaders.Add(_accessTokenHeaderKey, $"Bearer {accessToken}");
                var httpResponseMessage = await httpClient.GetAsync(new Uri(url));
                if (!httpResponseMessage.IsSuccessStatusCode) return null;
                var responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                var rayanContractResult = JsonSerializer.Deserialize<RayanContractsResult>(responseString, _jsonOptions);
                if (rayanContractResult is null || !rayanContractResult.Result!.Any()) return null;
                return rayanContractResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<string> GetRayanAccessToken(bool purgeMemoryCache = false)
        {
            if (purgeMemoryCache)
            {
                await _globalRedisCacheService.RemoveAsync(_accessTokenCacheKey);
            }
            if (_globalRedisCacheService.TryGetValue(_accessTokenCacheKey, out string? rayanAccessToken))
                return rayanAccessToken!;

            var httpClient = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_rayanConfig.BaseAuthorizeUrl}/authenticate");
            var requestBody = new
            {
                password = _rayanConfig.Password,
                username = _rayanConfig.Username,
                applicationKey = _rayanConfig.ApplicationKey
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), null, "application/json");
            request.Content = content;
            var response = await httpClient.SendAsync(request);

            var res = await response.Content.ReadAsStringAsync();
            var jsonObject = JObject.Parse(res);

            if (!response.IsSuccessStatusCode)
            {
                var errorCode = jsonObject["errorId"];
                if (errorCode is not null && Convert.ToInt32(errorCode) == 5000004)
                    request = new HttpRequestMessage(HttpMethod.Post, $"{_rayanConfig.BaseAuthorizeUrl}/authenticate/revoke");
                var revokeRequestBody = new { token = rayanAccessToken };
                content = new StringContent(JsonSerializer.Serialize(revokeRequestBody), null, "application/json");
                request.Content = content;
                var revokeResponse = await httpClient.SendAsync(request);
                res = await revokeResponse.Content.ReadAsStringAsync();
                jsonObject = JObject.Parse(res);
            }

            var accessToken = jsonObject["accessToken"]?.ToString();
            var ttl = Convert.ToInt64(jsonObject["ttl"]);
            await _globalRedisCacheService.SetStringAsync(_accessTokenCacheKey, accessToken!, ttl);

            return accessToken!;
        }
    }
}