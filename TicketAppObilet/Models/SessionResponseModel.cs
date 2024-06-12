using Newtonsoft.Json;
using RestSharp;

namespace TicketAppObilet.Models
{
    public class SessionResponseModel
    {
        [JsonProperty("data")]
        public DeviceSession Data { get; set; }

        [JsonProperty("status")]
        public string ResponseStatus { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("user-message")]
        public string UserMessage { get; set; }

        [JsonProperty("api-request-id")]
        public string ApiRequestID { get; set; }

        [JsonProperty("controller")]
        public string Controller { get; set; }
    }
    public class DeviceSession
    {
        [JsonProperty("session-id")]
        public string SessionID { get; set; }

        [JsonProperty("device-id")]
        public string DeviceID { get; set; }
    }
}
