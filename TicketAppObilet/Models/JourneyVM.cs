namespace TicketAppObilet.Models
{
    public class JourneyVM
    {
        public JourneyResponseData[] JourneyResponseData { get; set; }

        public string OriginName { get; set; }

        public string DestinationName { get; set; }

        public string DeperatureDate { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

        public string UserMessage { get; set; } = string.Empty;

    }
    public class JourneyDetailsVM
    {
        public JourneyResponseData Journey { get; set; }
    }
}
