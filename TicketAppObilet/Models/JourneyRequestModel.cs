using Newtonsoft.Json;

namespace TicketAppObilet.Models
{
    public class JourneyRequestModel
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; } = "en-En";

        [JsonProperty("device-session")]
        public DeviceSession DeviceSession { get; set; }

        [JsonProperty("data")]
        public JourneyRequestData Data { get; set; }
    }
    public class JourneyRequestData
    {
        [JsonProperty("origin-id")]
        public int OriginID { get; set; }

        [JsonProperty("destination-id")]
        public int DestinationID { get; set; }

        [JsonProperty("departure-date")]
        public string DepartureDate { get; set; }
    }
}
