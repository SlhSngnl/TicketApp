using System.Reflection;
using TicketAppObilet.Models;

namespace TicketAppObilet
{
    public class TicketService
    {
        private readonly OBiletApiClient _obiletApiClient;
        private readonly SessionService _sessionManager;
        public TicketService(OBiletApiClient obiletApiClient, SessionService sessionManager)
        {
            _obiletApiClient = obiletApiClient;
            _sessionManager = sessionManager;
        }

        public IndexVM GetBusLocations()
        {
            _sessionManager.CreateSession();

            LocationRequestModel locationRequestModel = new LocationRequestModel
            {
                DeviceSession = new DeviceSession()
                {
                    DeviceID = _sessionManager.GetDeviceId(),
                    SessionID = _sessionManager.GetSessionId()
                }
            };
            LocationResponseModel responseModel = _obiletApiClient.GetBusLocations(locationRequestModel);


            if (responseModel.ResponseStatus != "Success")
                return new IndexVM
                {
                    ErrorMessage = responseModel.Message,
                    UserMessage = responseModel.UserMessage
                };

            return new IndexVM
            {
                OriginID = responseModel.Data[0].ID,
                OriginLocations = new Microsoft.AspNetCore.Mvc.Rendering.SelectList
                          (responseModel.Data, "ID", "Name"),
                DestinationID = responseModel.Data[2].ID,
                DestinationLocations = new Microsoft.AspNetCore.Mvc.Rendering.SelectList
                          (responseModel.Data, "ID", "Name")
            };
        }
        public JourneyVM GetBusJourneys(JourneyDTO model)
        {
            _sessionManager.CreateSession();

            JourneyRequestModel journeyRequestModel = new JourneyRequestModel
            {
                DeviceSession = new DeviceSession()
                {
                    DeviceID = _sessionManager.GetDeviceId(),
                    SessionID = _sessionManager.GetSessionId()
                },
                Date = model.Date,
                Data = model.Data,
            };
            JourneyResponseModel responseModel = _obiletApiClient.GetBusJourneys(journeyRequestModel);

            if (responseModel.ResponseStatus != "Success")
                return new JourneyVM
                {
                    ErrorMessage = responseModel.Message,
                    UserMessage = responseModel.UserMessage
                };


            return new JourneyVM
            {
                JourneyResponseData = responseModel.Data.OrderBy(x=>x.Journey.Departure).ToArray(),
                DeperatureDate = model.Data.DepartureDate,
                DestinationName = responseModel.Data[0].Journey.Destination,
                OriginName = responseModel.Data[0].Journey.Origin,

            };
        }


    }
}

