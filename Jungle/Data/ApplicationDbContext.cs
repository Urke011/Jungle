using jungletribe.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace jungletribe.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {  
        }
//test branch
        public DbSet<Travelinfo> Travelinfo { get; set; }

    }
}
