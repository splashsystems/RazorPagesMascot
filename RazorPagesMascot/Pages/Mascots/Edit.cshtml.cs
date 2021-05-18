using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMascot.Data;
using RazorPagesMascot.Models;

namespace RazorPagesMascot.Pages.Mascots
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesMascot.Data.RazorPagesMascotContext _context;

        public EditModel(RazorPagesMascot.Data.RazorPagesMascotContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Mascot Mascot { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Mascot = await _context.Mascot.FirstOrDefaultAsync(m => m.ID == id);

            if (Mascot == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Mascot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MascotExists(Mascot.ID))
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

        private bool MascotExists(int id)
        {
            return _context.Mascot.Any(e => e.ID == id);
        }
    }
}
