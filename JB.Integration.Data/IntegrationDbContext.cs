using JB.Integration.Core.Models;
using JB.Integration.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System;

namespace JB.Integration.Data
{
    public class IntegrationDbContext : DbContext
    {
        public IntegrationDbContext(DbContextOptions<IntegrationDbContext> options)
        {
        }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Integration_Test;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IntegrationConfiguration.OnModelCreating(modelBuilder);
        }
    }
}
