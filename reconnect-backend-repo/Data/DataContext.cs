using System;
using Microsoft.EntityFrameworkCore;
using reconnect_backend_repo.Entities;

namespace reconnect_backend_repo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
       
    }
}

