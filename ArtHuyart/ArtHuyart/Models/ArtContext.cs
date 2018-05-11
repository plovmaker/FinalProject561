using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ArtHuyart.Models
{
    public class ArtContext : DbContext
    {
        public ArtContext(DbContextOptions<ArtContext> options)
        : base(options)
        {
        }

        public DbSet<Art> Art { get; set; }
    }
}
