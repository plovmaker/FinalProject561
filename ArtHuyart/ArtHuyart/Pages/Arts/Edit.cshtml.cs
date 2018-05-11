using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArtHuyart.Models;

namespace ArtHuyart.Pages.Arts
{
    public class EditModel : PageModel
    {
        private readonly ArtHuyart.Models.ArtContext _context;

        public EditModel(ArtHuyart.Models.ArtContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Art).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Art.Any(e => e.ID == Art.ID))
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

        private bool ArtExists(int id)
        {
            return _context.Art.Any(e => e.ID == id);
        }
    }
}
