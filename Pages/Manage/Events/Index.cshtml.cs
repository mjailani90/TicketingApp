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
    public class IndexModel : PageModel
    {
        private readonly TicketingApp.Data.AppDbContext _context;

        public IndexModel(TicketingApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<EventItem> EventItem { get;set; } = default!;

        public async Task OnGetAsync()
        {
            EventItem = await _context.Events.ToListAsync();
        }
    }
}
