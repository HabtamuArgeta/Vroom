using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vroom.Models;

namespace Vroom.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Vroom.Models.Make> Make { get; set; } = default!;
        public DbSet<Vroom.Models.Model> Model { get; set; } = default!;
        public DbSet<Vroom.Models.Currency> Currency { get; set; } = default!;
        public DbSet<Vroom.Models.Bike> Bike { get; set; } = default!;
    }
}
