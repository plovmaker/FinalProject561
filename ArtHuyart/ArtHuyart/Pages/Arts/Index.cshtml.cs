using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ArtHuyart.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ArtHuyart.Pages.Arts
{
    public class IndexModel : PageModel
    {
        private readonly ArtHuyart.Models.ArtContext _context;

        public IndexModel(ArtHuyart.Models.ArtContext context)
        {
            _context = context;
        }

        public IList<Art> Art { get;set; }
        public SelectList Genres { get; set; }
        public string ArtGenre { get; set; }

        public async Task OnGetAsync(string artGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Art
                                            orderby m.Genre
                                            select m.Genre;

            var arts = from m in _context.Art
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                arts = arts.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(artGenre))
            {
                arts = arts.Where(x => x.Genre == artGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Art = await arts.ToListAsync();
        }
    }
}
