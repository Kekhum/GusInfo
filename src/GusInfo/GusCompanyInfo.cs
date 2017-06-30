using Newtonsoft.Json;

namespace GusInfo
{
    public class GusCompanyInfo
    {
        [JsonProperty("Nazwa")]
        public string Name { get; internal set; }
        [JsonProperty("Regon")]
        public string Regon { get; internal set; }
        public string Nip { get; internal set; }

        [JsonProperty("Miejscowosc")]
        public string City { get; internal set; }
        [JsonProperty("KodPocztowy")]
        public string ZipCode { get; internal set; }
        [JsonProperty("Ulica")]
        public string Street { get; internal set; }
    }
}
