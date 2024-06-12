using Microsoft.AspNetCore.Mvc.Rendering;

namespace TicketAppObilet.Models
{
    public class IndexVM
    {
        public SelectList OriginLocations { get; set; }

        public SelectList DestinationLocations { get; set; }

        public int OriginID { get; set; }

        public int DestinationID { get; set; }

        public DateTime DepartureDate { get; set; } = DateTime.Now.AddDays(1);

        public string ErrorMessage { get; set; } = string.Empty;

        public string UserMessage { get; set; } = string.Empty;

    }
}
