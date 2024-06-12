using Newtonsoft.Json;

namespace TicketAppObilet.Models
{
    public class LocationRequestModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; } = DateTime.Now;

        [JsonProperty("language")]
        public string Language { get; set; } = "tr-TR";

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}
