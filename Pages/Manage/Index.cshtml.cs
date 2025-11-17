using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketingApp.Models;

namespace TicketingApp.Pages.Manage
{
    public class IndexModel : PageModel
    {

        private readonly TicketingApp.Data.AppDbContext _context;

        public IndexModel(TicketingApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<EventItem> Event { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Event = await _context.Events.ToListAsync();
        }
    }
}
