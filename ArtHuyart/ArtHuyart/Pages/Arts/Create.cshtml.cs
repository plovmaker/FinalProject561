using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ArtHuyart.Models;

namespace ArtHuyart.Pages.Arts
{
    public class CreateModel : PageModel
    {
        private readonly ArtHuyart.Models.ArtContext _context;

        public CreateModel(ArtHuyart.Models.ArtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Art Art { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Art.Add(Art);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}