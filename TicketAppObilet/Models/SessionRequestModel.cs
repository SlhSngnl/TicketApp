using Newtonsoft.Json;

namespace TicketAppObilet.Models
{
    public class SessionRequestModel
    {
        [JsonProperty("type")]
        public byte Type { get; set; }

        [JsonProperty("connection")]
        public ConnectionModel Connection { get; set; }

        [JsonProperty("browser")]
        public BrowserModel Browser { get; set; }
    }
    public class ConnectionModel
    {
        [JsonProperty("ip-address")]
        public string IpAddress { get; set; }

        [JsonProperty("port")]
        public string Port { get; set; }

        [JsonProperty("equipment-id")]
        public string EquipmentId { get; set; }

    }
    public class BrowserModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
