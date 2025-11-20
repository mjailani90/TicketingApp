using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketingApp.Data;
using TicketingApp.Models;
using TicketingApp.Models.ViewModels;

namespace TicketingApp.Pages.Manage.Events
{
    public class IndexModel : PageModel
    {
        private readonly TicketingApp.Data.AppDbContext _context;

        public IndexModel(TicketingApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<EventItem> EventItem { get;set; } = default!;
        public IList<EventWithCountVM> Events { get; set; } = new List<EventWithCountVM>();


        public async Task OnGetAsync()
        {
            //EventItem = await _context.Events.ToListAsync();

            Events = await (
                             from e in _context.Events
                             join t in _context.Ticket
                                 on e.EventID equals t.EventID into ticketGroup
                             select new EventWithCountVM
                             {
                                 Event = e,
                                 TicketsBooked = ticketGroup.Count()
                             }
                         ).ToListAsync();
        }
    }
}
