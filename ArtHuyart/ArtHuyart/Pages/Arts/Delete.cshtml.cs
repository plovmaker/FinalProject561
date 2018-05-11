using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtHuyart.Models;

namespace ArtHuyart.Pages.Arts
{
    public class DeleteModel : PageModel
    {
        private readonly ArtHuyart.Models.ArtContext _context;

        public DeleteModel(ArtHuyart.Models.ArtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Art Art { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Art = await _context.Art.SingleOrDefaultAsync(m => m.ID == id);

            if (Art == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Art = await _context.Art.FindAsync(id);

            if (Art != null)
            {
                _context.Art.Remove(Art);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
