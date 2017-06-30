using Newtonsoft.Json;

namespace GusInfo
{
    internal class SearchDataResponse
    {
        [JsonProperty("dane")]
        internal GusCompanyInfo Data { get; set; }
    }
}
