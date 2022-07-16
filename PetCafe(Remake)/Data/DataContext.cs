

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetCafe_Remake_.Models;

namespace PetCafe_Remake_.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<VisitTime> VisitTimes { get; set; }

    }
}
