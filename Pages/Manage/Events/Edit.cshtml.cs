using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TicketingApp.Data;
using TicketingApp.Models;

namespace TicketingApp.Pages.Manage.Events
{
    public class EditModel : PageModel
    {
        private readonly TicketingApp.Data.AppDbContext _context;

        public EditModel(TicketingApp.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventItem EventItem { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventitem =  await _context.Events.FirstOrDefaultAsync(m => m.EventID == id);
            if (eventitem == null)
            {
                return NotFound();
            }
            EventItem = eventitem;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EventItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventItemExists(EventItem.EventID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EventItemExists(int id)
        {
            return _context.Events.Any(e => e.EventID == id);
        }
    }
}
