using Newtonsoft.Json;
using RestSharp;

namespace TicketAppObilet.Models
{
    public class LocationResponseModel
    {
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

        [JsonProperty("data")]
        public LocationResponseData[] Data { get; set; }
    }

    public class LocationResponseData
    {
        [JsonProperty("id")]
        public int ID { get; set; }

        [JsonProperty("parent-id")]
        public int? ParentID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("zoom")]
        public string Zoom { get; set; }

        [JsonProperty("geo-location")]
        public GeoLocation GeoLocation { get; set; }

        [JsonProperty("tz-code")]
        public string TimeZoneCode { get; set; }

        [JsonProperty("weather-code")]
        public string WeatherCode { get; set; }

        [JsonProperty("rank")]
        public int? Rank { get; set; }

        [JsonProperty("reference-code")]
        public string RefCode { get; set; }

        [JsonProperty("keywords")]
        public string Keywords { get; set; }
    }
    public class GeoLocation
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("zoom")]
        public string Zoom { get; set; }
    }
}
