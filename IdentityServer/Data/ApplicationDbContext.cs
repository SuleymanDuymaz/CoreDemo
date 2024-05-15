using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity.Models;
using System.Reflection.Emit;

namespace Is4RoleDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().Ignore(c => c.AccessFailedCount)
                                      .Ignore(c => c.LockoutEnabled)
                                      .Ignore(c => c.PhoneNumber)
                                      .Ignore(c => c.PhoneNumberConfirmed)
                                      .Ignore(c => c.LockoutEnabled)
                                      .Ignore(c => c.LockoutEnd)
                                      .Ignore(c => c.EmailConfirmed)
                                      .Ignore(c => c.LockoutEnd)
                                      .Ignore(c => c.NormalizedEmail)




                                      .Ignore(c => c.TwoFactorEnabled);
        }
    }
}
