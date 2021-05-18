using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMascot.Data;
using RazorPagesMascot.Models;

namespace RazorPagesMascot.Pages.Mascots
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMascot.Data.RazorPagesMascotContext _context;

        public DetailsModel(RazorPagesMascot.Data.RazorPagesMascotContext context)
        {
            _context = context;
        }

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
    }
}
