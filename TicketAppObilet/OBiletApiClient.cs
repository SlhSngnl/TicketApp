using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using TicketAppObilet.Models;

namespace TicketAppObilet
{
    public class OBiletApiClient
    {
        private readonly AppSettings _appSettings;
        private readonly RestClient _client;

        public OBiletApiClient(AppSettings appSettings)
        {
            _appSettings = appSettings;
            _client = new RestClient(appSettings.ApiUrl);
            _client.AddDefaultHeader("Authorization", appSettings.ApiClientToken);
        }

        public SessionResponseModel GetSession(SessionRequestModel model)
        {
            var request = new RestRequest("client/getsession", Method.Post);
            var jsonBody = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            var response =  _client.Execute(request);

            if (response.IsSuccessful)
            {
                var returnData = JsonConvert.DeserializeObject<SessionResponseModel>(response.Content);
                return returnData;
            }
            else
            {
                throw new Exception($"Error: {response.StatusDescription}");
            }
        }

        public LocationResponseModel GetBusLocations(LocationRequestModel model)
        {
            var request = new RestRequest("location/getbuslocations", Method.Post);
            var jsonBody = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            var response =  _client.Execute(request);

            if (response.IsSuccessful)
            {
                var returnData = JsonConvert.DeserializeObject<LocationResponseModel>(response.Content);
                return returnData;
            }
            else
            {
                throw new Exception($"Error: {response.StatusDescription}");
            }
        }
        public JourneyResponseModel GetBusJourneys(JourneyRequestModel model)
        {
            var request = new RestRequest("journey/getbusjourneys", Method.Post);
            var jsonBody = JsonConvert.SerializeObject(model);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);

            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                var returnData = JsonConvert.DeserializeObject<JourneyResponseModel>(response.Content);
                return returnData;
            }
            else
            {
                throw new Exception($"Error: {response.StatusDescription}");
            }
        }

    }
}
