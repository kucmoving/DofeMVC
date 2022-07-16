using Newtonsoft.Json;

namespace PetCafe_Remake_.Helper
{
    public class IPInfo
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }

        [JsonProperty("hostname")]
        public string Hostname { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("loc")]
        public string Location { get; set; }

        [JsonProperty("timezone")]
        public string TimeZone { get; set; }
    }
}
