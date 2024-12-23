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
           
        public DbSet<Texi> Texis { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<User> users { get; set; }

    }
}
