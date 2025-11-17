using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketingApp.Models
{

    [Table("event")]
    public class EventItem
    {
        [Key]
        public int EventID { get; set; }
        public DateTime created_at { get; set; }
        public int? tenant_id { get; set; }
        public string? Event_Title { get; set; }
        public DateTime Event_Date { get; set; }
        public string? venue { get; set; }
        public string? Event_Status { get; set; }
        public int? NoofTickets { get; set; }
        public string? createdby { get; set; }
        public string? Venue_Location { get; set; }
    }

}
