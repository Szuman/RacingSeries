using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RacingSeries.Core.Domain;

namespace RacingSeries.Infrastructure.Repositories
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Track> Tracks { get; set; }
    }
}
