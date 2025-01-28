using System;
using Microsoft.EntityFrameworkCore;
using OrderTexi.Modals;

namespace OrderTexi.Data

{

    public class AppDbContext : DbContext
    {
        //public AppDbContext(AppDbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public AppDbContext()
        {

        }
        public DbSet<Texi> Texis { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
