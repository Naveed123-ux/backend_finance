using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using apl_project.Models;
using backend_finance.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace apl_project.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> DbContextOptions) : base(DbContextOptions)
        {

        }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles=new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName="ADMIN",
                },
                 new IdentityRole
                {
                    Name="User",
                    NormalizedName="User",
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}