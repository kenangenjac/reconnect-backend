using System;
using Microsoft.EntityFrameworkCore;
using reconnect_backend_repo.Entities;

namespace reconnect_backend_repo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMembers> TeamMembers { get; set; }
    
    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Event>()
    //            .HasOne(a => a.Location).WithMany(a => a.Activity).OnDelete(DeleteBehavior.NoAction);
    //    }
    }
}

