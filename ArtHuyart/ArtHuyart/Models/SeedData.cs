using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtHuyart.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ArtContext(
                serviceProvider.GetRequiredService<DbContextOptions<ArtContext>>()))
            {
                // Look for any movies.
                if (context.Art.Any())
                {
                    return;   // DB has been seeded
                }

                context.Art.AddRange(
                    new Art
                    {
                        Title = "Brig Mercury",
                        ReleaseDate = DateTime.Parse("1982-2-12"),
                        Genre = "Painting",
                        Price = 7.99M
                    },

                    new Art
                    {
                        Title = "Mother-Russia",
                        ReleaseDate = DateTime.Parse("1967-3-13"),
                        Genre = "Statue",
                        Price = 8.99M
                    },

                    new Art
                    {
                        Title = "Afrodita from Milos",
                        ReleaseDate = DateTime.Parse("0001-2-23"),
                        Genre = "Statue",
                        Price = 9.99M
                    },

                    new Art
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
