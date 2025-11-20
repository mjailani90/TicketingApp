using System.ComponentModel.DataAnnotations;

namespace TicketingApp.Models.ViewModels
{
    public class EventWithCountVM
    {
        public EventItem Event { get; set; }

        [Display(Name = "عدد التذاكر المحجوزة")]
        public int TicketsBooked { get; set; }
    }
}
