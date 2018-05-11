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
    public class DetailsModel : PageModel
    {
        private readonly ArtHuyart.Models.ArtContext _context;

        public DetailsModel(ArtHuyart.Models.ArtContext context)
        {
            _context = context;
        }

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
    }
}
