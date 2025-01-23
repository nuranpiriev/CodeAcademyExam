using ExamCake.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.DAL.Contexts
{
    public class AppDbContext:DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt) { }
        public DbSet<Designation> Designations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "eqqw3f", Name = "Admin", NormalizedName = "Admin" },
                new IdentityRole { Id = "dwffg3", Name = "User", NormalizedName = "USER" }
                );
            IdentityUser admin = new()
            {
                Id = "hiuhiw",
                NormalizedUserName = "ADMIN",
                UserName = "admin",
                PasswordHash = "admin123"
            };
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "eqqw3f",
                UserId = "hiuhiw"
            });

            base.OnModelCreating(builder);


        }
    }
}
