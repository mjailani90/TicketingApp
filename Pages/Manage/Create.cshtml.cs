using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketingApp.Data;
using TicketingApp.Models;

namespace TicketingApp.Pages.Manage.Events
{
    public class CreateModel : PageModel
    {
        private readonly TicketingApp.Data.AppDbContext _context;

        public CreateModel(TicketingApp.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EventItem EventItem { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Events.Add(EventItem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
