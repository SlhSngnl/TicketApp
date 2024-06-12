using Newtonsoft.Json;

namespace TicketAppObilet.Models
{
    public class JourneyDTO
    {
        public DateTime Date { get; set; }
        public string Language { get; set; } = "tr-TR";
        public JourneyRequestData Data { get; set; }
    }
}
