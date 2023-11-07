using DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    public class OrderDBContext : DbContext
    {
        public DbSet<DbOrders> Orders { get; set; }

        private const string ConnectionString =
           @"Server=localhost\sqlexpress;Database=hw_3_wild_berries;Trusted_Connection=True;Encrypt=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbOrders>()
              .HasKey(u => u.Id);
        }
    }
}