using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketingApp.Data;
using TicketingApp.Models;

namespace TicketingApp.Pages.Manage.Events
{
    public class DetailsModel : PageModel
    {
        private readonly TicketingApp.Data.AppDbContext _context;

        public DetailsModel(TicketingApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public EventItem EventItem { get; set; } = default!;
        public Ticket Ticket { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventitem = await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);
            var ticket = await _context.Ticket.FirstOrDefaultAsync(m => m.EventID == id);

            if (eventitem == null)
            {
                return NotFound();
            }
            else
            {
                EventItem = eventitem;
                Ticket = ticket;
            }
            return Page();
        }
    }
}
