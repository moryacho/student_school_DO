using DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Provider
{
    public class OfficeDBContext : DbContext
    {
        public DbSet<DbUser> Users { get; set; }

        private const string ConnectionString =
           @"Server=localhost\sqlexpress;Database=lt_practoce_30_10_code;Trusted_Connection=True;Encrypt=False;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
              .HasKey(u => u.Id);
        }
    }
}
